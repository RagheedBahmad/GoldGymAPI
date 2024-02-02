// namespace GoldGymAPI.Services;
// using PCSC;
// using PCSC.Iso7816;
//
// public void ConnectToReader()
// {
//     var contextFactory = ContextFactory.Instance;
//     using (var ctx = contextFactory.Establish(SCardScope.System))
//     {
//         using (var reader = ctx.ConnectReader("YourReaderName", SCardShareMode.Shared, SCardProtocol.Any))
//         {
//             // Use reader object for further operations
//         }
//     }
// }
//
// public interface INfcService
// {
//     Task<string> ReadTagAsync();
//     Task<bool> WriteTagAsync(string data);
// }
//
// public class NFCService : INfcService
// {
//     public async Task<string> ReadTagAsync()
//     {
//         // Implement reading logic here
//     }
//
//     public async Task<bool> WriteTagAsync(string data)
//     {
//         try
//         {
//             var writer = ConnectToWriter(); // Connect to your NFC writer
//             var tag = await WaitForTagAsync(writer); // Wait for an NFC tag
//
//             if(tag != null)
//             {
//                 await WriteDataAsync(tag, memberId); // Write the member ID to the tag
//                 return true; // Indicate success
//             }
//
//             return false; // No tag detected or write failed
//         }
//         catch (Exception ex)
//         {
//             // Handle or log the exception as appropriate
//             Console.WriteLine($"Error writing to NFC card: {ex.Message}");
//             return false;
//         }
//     }
// }