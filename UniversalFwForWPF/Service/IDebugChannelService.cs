using System;
using System.Collections.Generic;
using System.Text;

using DynamicData;

using UniversalFwForWPF.Models.Common;

namespace UniversalFwForWPF.Service
{
    public interface IDebugChannelService
    {

        public IObservableList<CommunicationMessageBase> DebugSourceList { get; }


        void Add(CommunicationMessageBase message);

        void RemoveFirstNum(int count);

        void ClearAllData();
    }
}
