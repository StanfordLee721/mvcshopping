using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
// <summary>引用自許老師的教學網站JohnsonNote</summary>
// BaseClass使用時機:
// 建立需手動管理的資源類別（如 LogService、FileManager、DbConnectionWrapper）
// 避免每個類別都重複寫 Dispose 模板
// 建立一個乾淨、安全、可擴充的資源管理架構
public class BaseClass : IDisposable
{
    #region 解構子
    private bool disposed = false;
    private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

    /// <summary>
    /// 解構子,實現IDisposable中的Dispose方法
    /// </summary>
    public void Dispose()
    {
        //必須為true
        Dispose(true);
        //通知垃圾回收機制不再調用終端子（析構器）
        GC.SuppressFinalize(this);
    }
    /// <summary>
    /// 解構子
    /// </summary>
    /// <param name="disposing">disposing</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        //解構時要執行的其它程式
        if (disposing)
        {
            handle.Dispose();
        }
        //讓類別知道自己已經被釋放
        disposed = true;
    }
    /// <summary>
    /// BaseClass 解構子
    /// </summary>
    ~BaseClass()
    {
        //必須為false
        Dispose(false);
    }
    #endregion
}
