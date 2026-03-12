using Dynastream.Fit;

namespace GarminTools.Infrastructure.FitFile;

public class FitFileService
{
    private readonly List<Mesg> _messages = [];
    private bool _isFirstMessage = true;
    private GarminDeviceToChange? _oldProductInfo;
    private GarminDeviceToChange? _newProductInfo;

    public byte[] Convert(byte[] fitSource, GarminDeviceToChange? garminDeviceToChange = null)
    {
        _newProductInfo = garminDeviceToChange ?? GarminDeviceToChange.GetDefaultTax();
        var decode = new Decode();
        var listener = new FitListener();
        

        decode.MesgEvent += listener.OnMesg;
        decode.MesgEvent += OnMesgCustom;
        decode.MesgDefinitionEvent += OnMesgDefinitionCustom;
        decode.DeveloperFieldDescriptionEvent += OnDeveloperFieldDescriptionCustom;
        
        using (var stream = new MemoryStream(fitSource))
        {
            decode.Read(stream);
        }

        var fitMessages = listener.FitMessages;

        foreach (FileIdMesg mesg in fitMessages.FileIdMesgs)
        {
            PrintFileIdMesg(mesg);
        }

        // Zapisz do pliku
        
    

        //FileStream fitDest = new FileStream($"{Guid.NewGuid()}.fit", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

        MemoryStream ms = new MemoryStream();
        // Write our header
        var encodeDemo = new Encode(ms, ProtocolVersion.V20);
        // Encode each message, a definition message is automatically generated and output if necessary
        encodeDemo.Write(_messages);

        // Update header datasize and file CRC
        encodeDemo.Close();
        ms.Close();
  
        return ms.ToArray();
    }

    private void OnMesgCustom(object sender, MesgEventArgs e)
    {
        Console.WriteLine(e.mesg.GetType());
        switch (e.mesg.Num)
        {
            case MesgNum.FileId:
            {
                var msg = new FileIdMesg(e.mesg);
                _oldProductInfo = new GarminDeviceToChange(
                    msg.GetManufacturer().GetValueOrDefault(),
                    msg.GetProduct().GetValueOrDefault(),
                    msg.GetSerialNumber().GetValueOrDefault(),
                    msg.GetProductNameAsString(),
                    msg.GetType().GetValueOrDefault());
                
                

                var productField = msg.Fields.FirstOrDefault(x => x.Name == "Product");
                if (productField != null)
                {
                    msg.RemoveField(msg.GetField(productField.Num));
                }

                msg.SetManufacturer(_newProductInfo!.Manufacturer);
                msg.SetGarminProduct(_newProductInfo.Product);
                msg.SetProductName(_newProductInfo.Name);
                msg.SetType(_newProductInfo.Type);
                
                _messages.Add(msg);
                _isFirstMessage = false;
                break;
            }
            case MesgNum.DeviceInfo:
            {
                var msg = new DeviceInfoMesg(e.mesg);
                if (msg.GetManufacturer() != _oldProductInfo!.Manufacturer && msg.GetProduct() != _oldProductInfo.Product)
                {
                    _messages.Add(msg);
                }
                break;
            }
            default:
                _messages.Add(e.mesg);
                break;
        }
    }
    
    static void OnMesgDefinitionCustom(object sender, MesgDefinitionEventArgs e)
    {
        Console.WriteLine("OnMesgDef: Received Defn for local message #{0}, global num {1}", e.mesgDef.LocalMesgNum, e.mesgDef.GlobalMesgNum);
        Console.WriteLine("\tIt has {0} fields {1} developer fields and is {2} bytes long",
            e.mesgDef.NumFields,
            e.mesgDef.NumDevFields,
            e.mesgDef.GetMesgSize());
    }
    private static void OnDeveloperFieldDescriptionCustom(object? sender, DeveloperFieldDescriptionEventArgs args)
    {
        Console.WriteLine("New Developer Field Description");
        Console.WriteLine("   App Id: {0}", args.Description.ApplicationId);
        Console.WriteLine("   App Version: {0}", args.Description.ApplicationVersion);
        Console.WriteLine("   Field Number: {0}", args.Description.FieldDefinitionNumber);
    }
    
    public static void PrintFileIdMesg(FileIdMesg mesg)
    {
        Console.WriteLine("File ID:");

        if (mesg.GetType() != null)
        {
            Console.Write("   Type: ");
            Console.WriteLine(mesg.GetType().Value);
        }

        if (mesg.GetManufacturer() != null)
        {
            Console.Write("   Manufacturer: ");
            Console.WriteLine(mesg.GetManufacturer());
        }

        if (mesg.GetProduct() != null)
        {
            Console.Write("   Product: ");
            Console.WriteLine(mesg.GetProduct());
        }

        if (mesg.GetSerialNumber() != null)
        {
            Console.Write("   Serial Number: ");
            Console.WriteLine(mesg.GetSerialNumber());
        }

        if (mesg.GetNumber() != null)
        {
            Console.Write("   Number: ");
            Console.WriteLine(mesg.GetNumber());
        }
    }
}

public record GarminDeviceToChange(ushort Manufacturer, ushort Product, uint SerialNumber, string Name, Dynastream.Fit.File Type)
{
    public static GarminDeviceToChange GetDefaultTax() => new(
        Dynastream.Fit.Manufacturer.Tacx, //89, 
        GarminProduct.TacxTrainingAppWin, //20533,
        2369583,
        "Tacx Training App Win",
        Dynastream.Fit.File.Activity); // Dynastream.Fit.ActivityTyoe ???);
};