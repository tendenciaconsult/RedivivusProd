using Simir.Domain.Interfaces.ServiceAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Redivivus.ServiceAgent.DataFileStorage
{
    public class ArmazenamentoArquivoAzure : IArmazenamentoArquivo
    {
        public async Task DeleteArquivo(string nmArquivo, string pasta)
        {
            // Retrieve storage account information from connection string
            // How to create a storage connection string - http://msdn.microsoft.com/en-us/library/azure/ee758697.aspx
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.GetStorageConnectionString());

            // Create a file client for interacting with the file service.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Create a share for organizing files and directories within the storage account.
            CloudFileShare share = fileClient.GetShareReference("testfiledemo");


            // Get a reference to the root directory of the share.        
            CloudFileDirectory root = share.GetRootDirectoryReference();

            // Create a directory under the root directory 
            CloudFileDirectory dir = root.GetDirectoryReference(pasta);

            // Uploading a local file to the directory created above
            CloudFile file = dir.GetFileReference(nmArquivo);

            await file.DeleteAsync();
        }

        public async Task<Stream> DownloadArquivo(string nmArquivo, string pasta)
        {
            // Retrieve storage account information from connection string
            // How to create a storage connection string - http://msdn.microsoft.com/en-us/library/azure/ee758697.aspx
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.GetStorageConnectionString());

            // Create a file client for interacting with the file service.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Create a share for organizing files and directories within the storage account.
            CloudFileShare share = fileClient.GetShareReference("testfiledemo");


            // Get a reference to the root directory of the share.        
            CloudFileDirectory root = share.GetRootDirectoryReference();

            // Create a directory under the root directory 
            CloudFileDirectory dir = root.GetDirectoryReference(pasta);

            // Uploading a local file to the directory created above
            CloudFile file = dir.GetFileReference(nmArquivo);
            
            return await file.OpenReadAsync();
        }

        public async Task UploadArquivo(TBArquivo arquivo, string pasta, Stream inputStream)
        {
            // Retrieve storage account information from connection string
            // How to create a storage connection string - http://msdn.microsoft.com/en-us/library/azure/ee758697.aspx
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.GetStorageConnectionString());

            // Create a file client for interacting with the file service.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Create a share for organizing files and directories within the storage account.
            CloudFileShare share = fileClient.GetShareReference("testfiledemo");

            await share.CreateIfNotExistsAsync();

            // Get a reference to the root directory of the share.        
            CloudFileDirectory root = share.GetRootDirectoryReference();

            // Create a directory under the root directory 
            CloudFileDirectory dir = root.GetDirectoryReference(pasta);
            await dir.CreateIfNotExistsAsync();

            // Uploading a local file to the directory created above
            CloudFile file = dir.GetFileReference(arquivo.nmArquivo);
            await file.UploadFromStreamAsync(inputStream);
        }

    }
}
