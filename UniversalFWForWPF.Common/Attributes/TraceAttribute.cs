using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFWForWPF.Common.Attributes
{
    //[Serializable]
    //public sealed class TraceAttribute : OnMethodBoundaryAspect
    //{
    //    private readonly string category;

    //    public TraceAttribute(string category)
    //    {
    //        this.category = category;
    //    }

    //    public string Category { get { return category; } }

    //    public override void OnEntry(MethodExecutionArgs args)
    //    {
    //        Trace.WriteLine(string.Format("{2}----Entering {0}.{1}.",
    //                                      args.Method.DeclaringType.Name,
    //                                      args.Method.Name, DateTime.Now.ToString()), category);

    //        for (int x = 0; x < args.Arguments.Count; x++)
    //        {
    //            Trace.WriteLine(args.Method.GetParameters()[x].Name + " = " +
    //                            args.Arguments.GetArgument(x));
    //        }
    //    }

    //    public override void OnExit(MethodExecutionArgs args)
    //    {
    //        Trace.WriteLine("Return Value: " + args.ReturnValue);

    //        Trace.WriteLine(string.Format("{2}---Leaving {0}.{1}.",
    //                                      args.Method.DeclaringType.Name,
    //                                      args.Method.Name, DateTime.Now.ToString()), category);
    //    }
    //}

    //public sealed class LogTraceListener : TraceListener
    //{
    //    public string FileName { set; get; }
    //    public LogTraceListener(string filename)
    //    {
    //        FileName = filename;
    //    }
    //    public override void Write(string message)
    //    {
    //        using (StreamWriter sw = new StreamWriter(FileName, true, Encoding.UTF8, Int16.MaxValue))
    //        {
    //            sw.Write(message);
    //        }
    //    }

    //    public override void WriteLine(string message)
    //    {
    //        using (StreamWriter sw = new StreamWriter(FileName, true, Encoding.UTF8, Int16.MaxValue))
    //        {
    //            sw.WriteLine(message);
    //        }
    //    }
    //}
}
