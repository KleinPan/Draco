using System;
using System.Reactive.Disposables;

 

using DynamicData;

using UniversalFwForWPF.Models.Common;

namespace UniversalFwForWPF.Service
{
    public class DebugChannelService : IDebugChannelService
    {
        private readonly SourceList<CommunicationMessageBase> debugSourceList = new SourceList<CommunicationMessageBase>();

        public IObservableList<CommunicationMessageBase> DebugSourceList => debugSourceList.AsObservableList();

        private readonly IDisposable _cleanup;

        public DebugChannelService()
        {
            _cleanup = new CompositeDisposable(debugSourceList);
        }

        public void Add(CommunicationMessageBase str)
        {
            debugSourceList.Add(str);
        }

        public void RemoveFirstNum(int count)
        {
            debugSourceList.RemoveRange(0, count);
        }

        public void ClearAllData()
        {
            debugSourceList.Clear();
        }

        public void Dispose()
        {
            _cleanup.Dispose();
        }
    }
}
