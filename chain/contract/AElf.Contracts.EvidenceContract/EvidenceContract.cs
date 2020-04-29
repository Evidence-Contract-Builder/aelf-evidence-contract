using System;
using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.EvidenceContract
{
    public class EvidenceContract : EvidenceContractContainer.EvidenceContractBase
    {
        public override BytesValue VerifyFiles(Hash id)
        {
            var fileReceived = State.FileReceived[id]; //得到原始文件

            if (fileReceived == null)
            {
                throw new AssertionException("File not found.");
            }

            var fileByte = fileReceived.FileByte;
            var hashCode = HashHelper.ComputeFrom(fileByte.ToByteArray());
            //比较哈希码
            return hashCode == id ? new BytesValue {Value = fileByte} : null;
        }

        public override Empty FilesToHash(FileReceived input)
        {
            //fileReceived: id,fileName,fileBytes,fileSize,saveTime
            Hash id = input.Id;
            var fileReceived = new FileReceived
            {
                Id = id,
                FileByte = input.FileByte,
                FileName = input.FileName,
                FileSize = input.FileSize,
                SaveTime = Context.CurrentBlockTime
            };
            State.FileReceived[id] = fileReceived;

            return new Empty();
        }
    }
}