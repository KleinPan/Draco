namespace Draco.Common.Datas
{
    /// <summary>
    /// 进度汇报用
    /// </summary>
    public enum SubTaskStatusEnum
    {
        None,
        WaitForStart,
        Running,
        Stop,
        End,
    }

    /// <summary>
    /// 操作通知用
    /// </summary>
    public enum MainTaskStatusEnum
    {
        Start,
        End,
    }
}
