﻿using System.Collections.Generic;
using System.Linq;
using Acs0;
using AElf.Contracts.Profit;
using AElf.Kernel;
using AElf.Kernel.Token;
using AElf.OS.Node.Application;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Blockchains.MainChain
{
    public partial class GenesisSmartContractDtoProvider
    {
        public IEnumerable<GenesisSmartContractDto> GetGenesisSmartContractDtosForEvidence()
        {
            var l = new List<GenesisSmartContractDto>();

            l.AddGenesisSmartContract(
                _codes.Single(kv => kv.Key.Contains("Evidence")).Value,
                HashHelper.ComputeFrom("AElf.ContractNames.EvidenceContract"),
                GenerateEvidenceInitializationCallList());

            return l;
        }

        private SystemContractDeploymentInput.Types.SystemTransactionMethodCallList GenerateEvidenceInitializationCallList()
        {
            var evidenceContractMethodCallList = new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList();

            return evidenceContractMethodCallList;
        }
    }
}