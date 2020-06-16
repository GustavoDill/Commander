using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Commander.AutoIt
{
    public static class AutoItX
    {
        /// <summary>
        /// Checks if currently running in 64bit.
        /// </summary>
        // Token: 0x060000E8 RID: 232 RVA: 0x000020D0 File Offset: 0x000002D0
        public static void Init()
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_Init64();
                return;
            }
            AutoItX_DLLImport.AU3_Init32();
        }

        /// <summary>
        /// Returns the last error code.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000E9 RID: 233 RVA: 0x000020E4 File Offset: 0x000002E4
        public static int ErrorCode()
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_error64();
            }
            return AutoItX_DLLImport.AU3_error32();
        }

        /// <summary>
        /// Changes the operation of various AutoIt functions/parameters.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="optionValue"></param>
        /// <returns></returns>
        // Token: 0x060000EA RID: 234 RVA: 0x000020F8 File Offset: 0x000002F8
        public static int AutoItSetOption(string option, int optionValue)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_AutoItSetOption64(option, optionValue);
            }
            return AutoItX_DLLImport.AU3_AutoItSetOption32(option, optionValue);
        }

        /// <summary>
        /// Changes the operation of various AutoIt functions/parameters.
        /// </summary>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000EB RID: 235 RVA: 0x00002110 File Offset: 0x00000310
        public static string ClipGet(int maxLen = 1048576)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ClipGet64(stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ClipGet32(stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Changes the operation of various AutoIt functions/parameters.
        /// </summary>
        /// <param name="text"></param>
        // Token: 0x060000EC RID: 236 RVA: 0x0000214B File Offset: 0x0000034B
        public static void ClipPut(string text)
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ClipPut64(text);
                return;
            }
            AutoItX_DLLImport.AU3_ClipPut32(text);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="button"></param>
        /// <param name="numClicks"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        // Token: 0x060000ED RID: 237 RVA: 0x00002161 File Offset: 0x00000361
        public static int ControlClick(string title, string text, string control, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlClick64(title, text, control, button, numClicks, x, y);
            }
            return AutoItX_DLLImport.AU3_ControlClick32(title, text, control, button, numClicks, x, y);
        }

        /// <summary>
        /// Changes the operation of various AutoIt functions/parameters.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="button"></param>
        /// <param name="numClicks"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        // Token: 0x060000EE RID: 238 RVA: 0x00002189 File Offset: 0x00000389
        public static int ControlClick(IntPtr winHandle, IntPtr controlHandle, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlClickByHandle64(winHandle, controlHandle, button, numClicks, x, y);
            }
            return AutoItX_DLLImport.AU3_ControlClickByHandle32(winHandle, controlHandle, button, numClicks, x, y);
        }

        /// <summary>
        /// Sends a command to a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000EF RID: 239 RVA: 0x000021B0 File Offset: 0x000003B0
        public static string ControlCommand(string title, string text, string control, string command, string extra, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlCommand64(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlCommand32(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sends a command to a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000F0 RID: 240 RVA: 0x000021F8 File Offset: 0x000003F8
        public static string ControlCommand(IntPtr winHandle, IntPtr controlHandle, string command, string extra, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlCommandByHandle64(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlCommandByHandle32(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sends a command to a ListView32 control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000F1 RID: 241 RVA: 0x0000223C File Offset: 0x0000043C
        public static string ControlListView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlListView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlListView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sends a command to a ListView32 control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000F2 RID: 242 RVA: 0x00002288 File Offset: 0x00000488
        public static string ControlListView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlListViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlListViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Disables or "grays-out" a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F3 RID: 243 RVA: 0x000022D0 File Offset: 0x000004D0
        public static int ControlDisable(string title, string text, string control)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlDisable64(title, text, control);
            }
            return AutoItX_DLLImport.AU3_ControlDisable32(title, text, control);
        }

        /// <summary>
        /// Disables or "grays-out" a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F4 RID: 244 RVA: 0x000022EA File Offset: 0x000004EA
        public static int ControlDisable(IntPtr winHandle, IntPtr controlHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlDisableByHandle64(winHandle, controlHandle);
            }
            return AutoItX_DLLImport.AU3_ControlDisableByHandle32(winHandle, controlHandle);
        }

        /// <summary>
        /// Enables a "grayed-out" control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F5 RID: 245 RVA: 0x00002302 File Offset: 0x00000502
        public static int ControlEnable(string title, string text, string control)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlEnable64(title, text, control);
            }
            return AutoItX_DLLImport.AU3_ControlEnable32(title, text, control);
        }

        /// <summary>
        /// Enables a "grayed-out" control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F6 RID: 246 RVA: 0x0000231C File Offset: 0x0000051C
        public static int ControlEnable(IntPtr winHandle, IntPtr controlHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlEnableByHandle64(winHandle, controlHandle);
            }
            return AutoItX_DLLImport.AU3_ControlEnableByHandle32(winHandle, controlHandle);
        }

        /// <summary>
        /// Sets input focus to a given control on a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F7 RID: 247 RVA: 0x00002334 File Offset: 0x00000534
        public static int ControlFocus(string title, string text, string control)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlFocus64(title, text, control);
            }
            return AutoItX_DLLImport.AU3_ControlFocus32(title, text, control);
        }

        /// <summary>
        /// Sets input focus to a given control on a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x060000F8 RID: 248 RVA: 0x0000234E File Offset: 0x0000054E
        public static int ControlFocus(IntPtr winHandle, IntPtr controlHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlFocusByHandle64(winHandle, controlHandle);
            }
            return AutoItX_DLLImport.AU3_ControlFocusByHandle32(winHandle, controlHandle);
        }

        /// <summary>
        /// Returns the ControlRef# of the control that has keyboard focus within a specified window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000F9 RID: 249 RVA: 0x00002368 File Offset: 0x00000568
        public static string ControlGetFocus(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetFocus64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetFocus32(title, text, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the ControlRef# of the control that has keyboard focus within a specified window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000FA RID: 250 RVA: 0x000023A8 File Offset: 0x000005A8
        public static string ControlGetFocus(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetFocusByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetFocusByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the internal handle of a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x060000FB RID: 251 RVA: 0x000023E5 File Offset: 0x000005E5
        public static IntPtr ControlGetHandle(IntPtr winHandle, string control = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlGetHandle64(winHandle, control);
            }
            return AutoItX_DLLImport.AU3_ControlGetHandle32(winHandle, control);
        }

        /// <summary>
        /// Retrieves the internal handle of a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000FC RID: 252 RVA: 0x00002400 File Offset: 0x00000600
        public static string ControlGetHandleAsText(string title = "", string text = "", string control = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetHandleAsText64(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetHandleAsText32(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the position and size of a control relative to it's window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x060000FD RID: 253 RVA: 0x00002444 File Offset: 0x00000644
        public static Rectangle ControlGetPos(string title = "", string text = "", string control = "")
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetPos64(title, text, control, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetPos32(title, text, control, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves the position and size of a control relative to it's window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x060000FE RID: 254 RVA: 0x000024CC File Offset: 0x000006CC
        public static Rectangle ControlGetPos(IntPtr winHandle, IntPtr controlHandle)
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetPosByHandle64(winHandle, controlHandle, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetPosByHandle32(winHandle, controlHandle, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves text from a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x060000FF RID: 255 RVA: 0x00002550 File Offset: 0x00000750
        public static string ControlGetText(string title, string text, string control, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetText64(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetText32(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves text from a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000100 RID: 256 RVA: 0x00002594 File Offset: 0x00000794
        public static string ControlGetText(IntPtr winHandle, IntPtr controlHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetTextByHandle64(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetTextByHandle32(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Hides a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x06000101 RID: 257 RVA: 0x000025D3 File Offset: 0x000007D3
        public static int ControlHide(string title, string text, string control)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlHide64(title, text, control);
            }
            return AutoItX_DLLImport.AU3_ControlHide32(title, text, control);
        }

        /// <summary>
        /// Hides a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x06000102 RID: 258 RVA: 0x000025ED File Offset: 0x000007ED
        public static int ControlHide(IntPtr winHandle, IntPtr controlHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlHideByHandle64(winHandle, controlHandle);
            }
            return AutoItX_DLLImport.AU3_ControlHideByHandle32(winHandle, controlHandle);
        }

        /// <summary>
        /// Moves a control within a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        // Token: 0x06000103 RID: 259 RVA: 0x00002605 File Offset: 0x00000805
        public static int ControlMove(string title, string text, string control, int x, int y, int width = -1, int height = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlMove64(title, text, control, x, y, width, height);
            }
            return AutoItX_DLLImport.AU3_ControlMove32(title, text, control, x, y, width, height);
        }

        /// <summary>
        /// Moves a control within a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        // Token: 0x06000104 RID: 260 RVA: 0x0000262D File Offset: 0x0000082D
        public static int ControlMove(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width = -1, int height = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlMoveByHandle64(winHandle, controlHandle, x, y, width, height);
            }
            return AutoItX_DLLImport.AU3_ControlMoveByHandle32(winHandle, controlHandle, x, y, width, height);
        }

        /// <summary>
        /// Sends a string of characters to a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        // Token: 0x06000105 RID: 261 RVA: 0x00002651 File Offset: 0x00000851
        public static int ControlSend(string title, string text, string control, string sendText, int mode = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSend64(title, text, control, sendText, mode);
            }
            return AutoItX_DLLImport.AU3_ControlSend32(title, text, control, sendText, mode);
        }

        /// <summary>
        /// Sends a string of characters to a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        // Token: 0x06000106 RID: 262 RVA: 0x00002671 File Offset: 0x00000871
        public static int ControlSend(IntPtr winHandle, IntPtr controlHandle, string sendText, int mode = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSendByHandle64(winHandle, controlHandle, sendText, mode);
            }
            return AutoItX_DLLImport.AU3_ControlSendByHandle32(winHandle, controlHandle, sendText, mode);
        }

        /// <summary>
        /// Sets text of a control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="controlText"></param>
        /// <returns></returns>
        // Token: 0x06000107 RID: 263 RVA: 0x0000268D File Offset: 0x0000088D
        public static int ControlSetText(string title, string text, string control, string controlText)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSetText64(title, text, control, controlText);
            }
            return AutoItX_DLLImport.AU3_ControlSetText32(title, text, control, controlText);
        }

        /// <summary>
        /// Sets text of a control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="controlText"></param>
        /// <returns></returns>
        // Token: 0x06000108 RID: 264 RVA: 0x000026A9 File Offset: 0x000008A9
        public static int ControlSetText(IntPtr winHandle, IntPtr controlHandle, string controlText)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSetTextByHandle64(winHandle, controlHandle, controlText);
            }
            return AutoItX_DLLImport.AU3_ControlSetTextByHandle32(winHandle, controlHandle, controlText);
        }

        /// <summary>
        /// Shows a control that was hidden.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <returns></returns>
        // Token: 0x06000109 RID: 265 RVA: 0x000026C3 File Offset: 0x000008C3
        public static int ControlShow(string title, string text, string control)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlShow64(title, text, control);
            }
            return AutoItX_DLLImport.AU3_ControlShow32(title, text, control);
        }

        /// <summary>
        /// Shows a control that was hidden.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <returns></returns>
        // Token: 0x0600010A RID: 266 RVA: 0x000026DD File Offset: 0x000008DD
        public static int ControlShow(IntPtr winHandle, IntPtr controlHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlShowByHandle64(winHandle, controlHandle);
            }
            return AutoItX_DLLImport.AU3_ControlShowByHandle32(winHandle, controlHandle);
        }

        /// <summary>
        /// Sends a command to a TreeView32 control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x0600010B RID: 267 RVA: 0x000026F8 File Offset: 0x000008F8
        public static string ControlTreeView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlTreeView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlTreeView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sends a command to a TreeView32 control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x0600010C RID: 268 RVA: 0x00002744 File Offset: 0x00000944
        public static string ControlTreeView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlTreeViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlTreeViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Maps a network drive.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="share"></param>
        /// <param name="flags"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // Token: 0x0600010D RID: 269 RVA: 0x0000278C File Offset: 0x0000098C
        public static string DriveMapAdd(string device, string share, int flags = 0, string user = "", string password = "")
        {
            StringBuilder stringBuilder = new StringBuilder(4);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_DriveMapAdd64(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_DriveMapAdd32(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Disconnects a network drive.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        // Token: 0x0600010E RID: 270 RVA: 0x000027D3 File Offset: 0x000009D3
        public static int DriveMapDel(string device)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_DriveMapDel64(device);
            }
            return AutoItX_DLLImport.AU3_DriveMapDel32(device);
        }

        /// <summary>
        /// Retreives the details of a mapped drive.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        // Token: 0x0600010F RID: 271 RVA: 0x000027EC File Offset: 0x000009EC
        public static string DriveMapGet(string device)
        {
            StringBuilder stringBuilder = new StringBuilder(260);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_DriveMapGet64(device, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_DriveMapGet32(device, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Checks if the current user has administrator privileges.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000110 RID: 272 RVA: 0x0000282D File Offset: 0x00000A2D
        public static int IsAdmin()
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_IsAdmin64();
            }
            return AutoItX_DLLImport.AU3_IsAdmin32();
        }

        /// <summary>
        /// Perform a mouse click operation.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="numClicks"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        // Token: 0x06000111 RID: 273 RVA: 0x00002841 File Offset: 0x00000A41
        public static int MouseClick(string button = "LEFT", int x = -2147483647, int y = -2147483647, int numClicks = 1, int speed = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseClick64(button, x, y, numClicks, speed);
            }
            return AutoItX_DLLImport.AU3_MouseClick32(button, x, y, numClicks, speed);
        }

        /// <summary>
        /// Perform a mouse click and drag operation.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        // Token: 0x06000112 RID: 274 RVA: 0x00002861 File Offset: 0x00000A61
        public static int MouseClickDrag(string button, int x1, int y1, int x2, int y2, int speed = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseClickDrag64(button, x1, y1, x2, y2, speed);
            }
            return AutoItX_DLLImport.AU3_MouseClickDrag32(button, x1, y1, x2, y2, speed);
        }

        /// <summary>
        /// Perform a mouse down event at the current mouse position.
        /// </summary>
        /// <param name="button"></param>
        // Token: 0x06000113 RID: 275 RVA: 0x00002885 File Offset: 0x00000A85
        public static void MouseDown(string button = "LEFT")
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseDown64(button);
                return;
            }
            AutoItX_DLLImport.AU3_MouseDown32(button);
        }

        /// <summary>
        /// Returns a cursor ID Number of the current Mouse Cursor.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000114 RID: 276 RVA: 0x0000289B File Offset: 0x00000A9B
        public static int MouseGetCursor()
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseGetCursor64();
            }
            return AutoItX_DLLImport.AU3_MouseGetCursor32();
        }

        /// <summary>
        /// Retrieves the current position of the mouse cursor.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000115 RID: 277 RVA: 0x000028B0 File Offset: 0x00000AB0
        public static Point MouseGetPos()
        {
            AutoItX_DLLImport.POINT point = default(AutoItX_DLLImport.POINT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseGetPos64(ref point);
            }
            else
            {
                AutoItX_DLLImport.AU3_MouseGetPos32(ref point);
            }
            Point result = new Point(point.x, point.y);
            return result;
        }

        /// <summary>
        /// Moves the mouse pointer.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        // Token: 0x06000116 RID: 278 RVA: 0x000028F2 File Offset: 0x00000AF2
        public static int MouseMove(int x, int y, int speed = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseMove64(x, y, speed);
            }
            return AutoItX_DLLImport.AU3_MouseMove32(x, y, speed);
        }

        /// <summary>
        /// Perform a mouse up event at the current mouse position.
        /// </summary>
        /// <param name="button"></param>
        // Token: 0x06000117 RID: 279 RVA: 0x0000290C File Offset: 0x00000B0C
        public static void MouseUp(string button = "LEFT")
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseUp64(button);
                return;
            }
            AutoItX_DLLImport.AU3_MouseUp32(button);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="numClicks"></param>
        // Token: 0x06000118 RID: 280 RVA: 0x00002922 File Offset: 0x00000B22
        public static void MouseWheel(string direction, int numClicks)
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseWheel64(direction, numClicks);
                return;
            }
            AutoItX_DLLImport.AU3_MouseWheel32(direction, numClicks);
        }

        /// <summary>
        /// Moves the mouse wheel up or down.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        // Token: 0x06000119 RID: 281 RVA: 0x0000293C File Offset: 0x00000B3C
        public static uint PixelChecksum(Rectangle rect, int step = 1)
        {
            AutoItX_DLLImport.RECT rect2;
            rect2.left = rect.Left;
            rect2.top = rect.Top;
            rect2.right = rect.Right;
            rect2.bottom = rect.Bottom;
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_PixelChecksum64(ref rect2, step);
            }
            return AutoItX_DLLImport.AU3_PixelChecksum32(ref rect2, step);
        }

        /// <summary>
        /// Returns a pixel color according to x,y pixel coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        // Token: 0x0600011A RID: 282 RVA: 0x00002999 File Offset: 0x00000B99
        public static int PixelGetColor(int x, int y)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_PixelGetColor64(x, y);
            }
            return AutoItX_DLLImport.AU3_PixelGetColor32(x, y);
        }

        /// <summary>
        /// Searches a rectangle of pixels for the pixel color provided.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="shade"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        // Token: 0x0600011B RID: 283 RVA: 0x000029B4 File Offset: 0x00000BB4
        public static Point PixelSearch(Rectangle rect, int color, int shade = 0, int step = 1)
        {
            AutoItX_DLLImport.RECT rect2;
            rect2.left = rect.Left;
            rect2.top = rect.Top;
            rect2.right = rect.Right;
            rect2.bottom = rect.Bottom;
            AutoItX_DLLImport.POINT point = default(AutoItX_DLLImport.POINT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_PixelSearch64(ref rect2, color, shade, step, ref point);
            }
            else
            {
                AutoItX_DLLImport.AU3_PixelSearch32(ref rect2, color, shade, step, ref point);
            }
            Point result = new Point(point.x, point.y);
            return result;
        }

        /// <summary>
        /// Terminates a named process.
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        // Token: 0x0600011C RID: 284 RVA: 0x00002A38 File Offset: 0x00000C38
        public static int ProcessClose(string process)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessClose64(process);
            }
            return AutoItX_DLLImport.AU3_ProcessClose32(process);
        }

        /// <summary>
        /// Checks to see if a specified process exists.
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        // Token: 0x0600011D RID: 285 RVA: 0x00002A4E File Offset: 0x00000C4E
        public static int ProcessExists(string process)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessExists64(process);
            }
            return AutoItX_DLLImport.AU3_ProcessExists32(process);
        }

        /// <summary>
        /// Changes the priority of a process.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        // Token: 0x0600011E RID: 286 RVA: 0x00002A64 File Offset: 0x00000C64
        public static int ProcessSetPriority(string process, int priority)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessSetPriority64(process, priority);
            }
            return AutoItX_DLLImport.AU3_ProcessSetPriority32(process, priority);
        }

        /// <summary>
        /// Pauses script execution until a given process exists.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x0600011F RID: 287 RVA: 0x00002A7C File Offset: 0x00000C7C
        public static int ProcessWait(string process, int timeout)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessWait64(process, timeout);
            }
            return AutoItX_DLLImport.AU3_ProcessWait32(process, timeout);
        }

        /// <summary>
        /// Pauses script execution until a given process does not exist.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000120 RID: 288 RVA: 0x00002A94 File Offset: 0x00000C94
        public static int ProcessWaitClose(string process, int timeout)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessWaitClose64(process, timeout);
            }
            return AutoItX_DLLImport.AU3_ProcessWaitClose32(process, timeout);
        }

        /// <summary>
        /// Runs an external program.
        /// </summary>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        /// <returns></returns>
        // Token: 0x06000121 RID: 289 RVA: 0x00002AAC File Offset: 0x00000CAC
        public static int Run(string program, string dir, int showFlag = 1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_Run64(program, dir, showFlag);
            }
            return AutoItX_DLLImport.AU3_Run32(program, dir, showFlag);
        }

        /// <summary>
        /// Runs an external program as a specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="domain"></param>
        /// <param name="password"></param>
        /// <param name="logonFlag"></param>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        /// <returns></returns>
        // Token: 0x06000122 RID: 290 RVA: 0x00002AC6 File Offset: 0x00000CC6
        public static int RunAs(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunAs64(user, domain, password, logonFlag, program, dir, showFlag);
            }
            return AutoItX_DLLImport.AU3_RunAs32(user, domain, password, logonFlag, program, dir, showFlag);
        }

        /// <summary>
        /// Runs an external program as a specified user and wait for it to close.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="domain"></param>
        /// <param name="password"></param>
        /// <param name="logonFlag"></param>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        /// <returns></returns>
        // Token: 0x06000123 RID: 291 RVA: 0x00002AEE File Offset: 0x00000CEE
        public static int RunAsWait(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunAsWait64(user, domain, password, logonFlag, program, dir, showFlag);
            }
            return AutoItX_DLLImport.AU3_RunAsWait32(user, domain, password, logonFlag, program, dir, showFlag);
        }

        /// <summary>
        /// Runs an external program and wait for it to close.
        /// </summary>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        /// <returns></returns>
        // Token: 0x06000124 RID: 292 RVA: 0x00002B16 File Offset: 0x00000D16
        public static int RunWait(string program, string dir, int showFlag = 1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunWait64(program, dir, showFlag);
            }
            return AutoItX_DLLImport.AU3_RunWait32(program, dir, showFlag);
        }

        /// <summary>
        /// Sends simulated keystrokes to the active window.
        /// </summary>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        // Token: 0x06000125 RID: 293 RVA: 0x00002B30 File Offset: 0x00000D30
        public static void Send(string sendText, int mode = 0)
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_Send64(sendText, mode);
                return;
            }
            AutoItX_DLLImport.AU3_Send32(sendText, mode);
        }

        /// <summary>
        /// Shut down the system.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        // Token: 0x06000126 RID: 294 RVA: 0x00002B48 File Offset: 0x00000D48
        public static int Shutdown(int flag)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_Shutdown64(flag);
            }
            return AutoItX_DLLImport.AU3_Shutdown32(flag);
        }

        /// <summary>
        /// Pause for specified number of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        // Token: 0x06000127 RID: 295 RVA: 0x00002B5E File Offset: 0x00000D5E
        public static void Sleep(int milliseconds)
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_Sleep64(milliseconds);
                return;
            }
            AutoItX_DLLImport.AU3_Sleep32(milliseconds);
        }

        /// <summary>
        /// Retrieves the text from a standard status bar control.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="part"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000128 RID: 296 RVA: 0x00002B74 File Offset: 0x00000D74
        public static string StatusBarGetText(string title = "", string text = "", int part = 1, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_StatusbarGetText64(title, text, part, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_StatusbarGetText32(title, text, part, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the text from a standard status bar control.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="part"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000129 RID: 297 RVA: 0x00002BB8 File Offset: 0x00000DB8
        public static string StatusBarGetText(IntPtr winHandle, int part = 1, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_StatusbarGetTextByHandle64(winHandle, part, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_StatusbarGetTextByHandle32(winHandle, part, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the text from a standard status bar control.
        /// </summary>
        /// <param name="tip"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // Token: 0x0600012A RID: 298 RVA: 0x00002BF7 File Offset: 0x00000DF7
        public static void ToolTip(string tip, int x = -2147483647, int y = -2147483647)
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_ToolTip64(tip, x, y);
                return;
            }
            AutoItX_DLLImport.AU3_ToolTip32(tip, x, y);
        }

        /// <summary>
        /// Activates (gives focus to) a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x0600012B RID: 299 RVA: 0x00002C11 File Offset: 0x00000E11
        public static int WinActivate(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActivate64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinActivate32(title, text);
        }

        /// <summary>
        /// Activates (gives focus to) a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x0600012C RID: 300 RVA: 0x00002C29 File Offset: 0x00000E29
        public static int WinActivate(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActivateByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinActivateByHandle32(winHandle);
        }

        /// <summary>
        /// Checks to see if a specified window exists and is currently active.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x0600012D RID: 301 RVA: 0x00002C3F File Offset: 0x00000E3F
        public static int WinActive(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActive64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinActive32(title, text);
        }

        /// <summary>
        /// Checks to see if a specified window exists and is currently active.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x0600012E RID: 302 RVA: 0x00002C57 File Offset: 0x00000E57
        public static int WinActive(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActiveByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinActiveByHandle32(winHandle);
        }

        /// <summary>
        /// Checks to see if a specified window exists.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x0600012F RID: 303 RVA: 0x00002C6D File Offset: 0x00000E6D
        public static int WinExists(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinExists64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinExists32(title, text);
        }

        /// <summary>
        /// Checks to see if a specified window exists.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x06000130 RID: 304 RVA: 0x00002C85 File Offset: 0x00000E85
        public static int WinExists(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinExistsByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinExistsByHandle32(winHandle);
        }

        /// <summary>
        /// Closes a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x06000131 RID: 305 RVA: 0x00002C9B File Offset: 0x00000E9B
        public static int WinClose(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinClose64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinClose32(title, text);
        }

        /// <summary>
        /// Closes a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x06000132 RID: 306 RVA: 0x00002CB3 File Offset: 0x00000EB3
        public static int WinClose(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinCloseByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinCloseByHandle32(winHandle);
        }

        /// <summary>
        /// Returns the coordinates of the caret in the foreground window.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000133 RID: 307 RVA: 0x00002CCC File Offset: 0x00000ECC
        public static Point WinGetCaretPos()
        {
            AutoItX_DLLImport.POINT point;
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetCaretPos64(out point);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetCaretPos32(out point);
            }
            Point result = new Point(point.x, point.y);
            return result;
        }

        /// <summary>
        /// Retrieves the classes from a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000134 RID: 308 RVA: 0x00002D08 File Offset: 0x00000F08
        public static string WinGetClassList(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClassList64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClassList32(title, text, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the classes from a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000135 RID: 309 RVA: 0x00002D48 File Offset: 0x00000F48
        public static string WinGetClassList(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClassListByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClassListByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the size of a given window's client area.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x06000136 RID: 310 RVA: 0x00002D88 File Offset: 0x00000F88
        public static Rectangle WinGetClientSize(string title = "", string text = "")
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClientSize64(title, text, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClientSize32(title, text, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves the size of a given window's client area.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x06000137 RID: 311 RVA: 0x00002E0C File Offset: 0x0000100C
        public static Rectangle WinGetClientSize(IntPtr winHandle)
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClientSizeByHandle64(winHandle, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClientSizeByHandle32(winHandle, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves the internal handle of a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x06000138 RID: 312 RVA: 0x00002E8D File Offset: 0x0000108D
        public static IntPtr WinGetHandle(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetHandle64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinGetHandle32(title, text);
        }

        /// <summary>
        /// Retrieves the internal handle of a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000139 RID: 313 RVA: 0x00002EA8 File Offset: 0x000010A8
        public static string WinGetHandleAsText(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetHandleAsText64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetHandleAsText32(title, text, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the position and size of a given window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x0600013A RID: 314 RVA: 0x00002EE8 File Offset: 0x000010E8
        public static Rectangle WinGetPos(string title = "", string text = "")
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetPos64(title, text, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetPos32(title, text, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves the position and size of a given window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x0600013B RID: 315 RVA: 0x00002F6C File Offset: 0x0000116C
        public static Rectangle WinGetPos(IntPtr winHandle)
        {
            AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetPosByHandle64(winHandle, ref rect);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetPosByHandle32(winHandle, ref rect);
            }
            return new Rectangle
            {
                X = rect.left,
                Y = rect.top,
                Width = rect.right - rect.left,
                Height = rect.bottom - rect.top
            };
        }

        /// <summary>
        /// Retrieves the Process ID (PID) associated with a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x0600013C RID: 316 RVA: 0x00002FED File Offset: 0x000011ED
        public static uint WinGetProcess(string title = "", string text = "", int maxLen = 65535)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetProcess64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinGetProcess32(title, text);
        }

        /// <summary>
        /// Retrieves the Process ID (PID) associated with a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x0600013D RID: 317 RVA: 0x00003005 File Offset: 0x00001205
        public static uint WinGetProcess(IntPtr winHandle, int maxLen = 65535)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetProcessByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinGetProcessByHandle32(winHandle);
        }

        /// <summary>
        /// Retrieves the state of a given window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x0600013E RID: 318 RVA: 0x0000301B File Offset: 0x0000121B
        public static int WinGetState(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetState64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinGetState32(title, text);
        }

        /// <summary>
        /// Retrieves the state of a given window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x0600013F RID: 319 RVA: 0x00003033 File Offset: 0x00001233
        public static int WinGetState(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetStateByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinGetStateByHandle32(winHandle);
        }

        /// <summary>
        /// Retrieves the text from a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000140 RID: 320 RVA: 0x0000304C File Offset: 0x0000124C
        public static string WinGetText(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetText64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetText32(title, text, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the text from a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000141 RID: 321 RVA: 0x0000308C File Offset: 0x0000128C
        public static string WinGetText(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTextByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTextByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the full title from a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000142 RID: 322 RVA: 0x000030CC File Offset: 0x000012CC
        public static string WinGetTitle(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTitle64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTitle32(title, text, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Retrieves the full title from a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        /// <returns></returns>
        // Token: 0x06000143 RID: 323 RVA: 0x0000310C File Offset: 0x0000130C
        public static string WinGetTitle(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTitleByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTitleByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Forces a window to close.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <returns></returns>
        // Token: 0x06000144 RID: 324 RVA: 0x00003149 File Offset: 0x00001349
        public static int WinKill(string title = "", string text = "")
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinKill64(title, text);
            }
            return AutoItX_DLLImport.AU3_WinKill32(title, text);
        }

        /// <summary>
        /// Forces a window to close.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <returns></returns>
        // Token: 0x06000145 RID: 325 RVA: 0x00003161 File Offset: 0x00001361
        public static int WinKill(IntPtr winHandle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinKillByHandle64(winHandle);
            }
            return AutoItX_DLLImport.AU3_WinKillByHandle32(winHandle);
        }

        /// <summary>
        /// Minimizes all windows.
        /// </summary>
        // Token: 0x06000146 RID: 326 RVA: 0x00003177 File Offset: 0x00001377
        public static void WinMinimizeAll()
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinMinimizeAll64();
                return;
            }
            AutoItX_DLLImport.AU3_WinMinimizeAll32();
        }

        /// <summary>
        /// Undoes a previous WinMinimizeAll function.
        /// </summary>
        // Token: 0x06000147 RID: 327 RVA: 0x0000318B File Offset: 0x0000138B
        public static void WinMinimizeAllUndo()
        {
            if (AutoItX.Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinMinimizeAllUndo64();
                return;
            }
            AutoItX_DLLImport.AU3_WinMinimizeAllUndo32();
        }

        /// <summary>
        /// Moves and/or resizes a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        // Token: 0x06000148 RID: 328 RVA: 0x0000319F File Offset: 0x0000139F
        public static int WinMove(string title, string text, int x, int y, int width = -1, int height = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinMove64(title, text, x, y, width, height);
            }
            return AutoItX_DLLImport.AU3_WinMove32(title, text, x, y, width, height);
        }

        /// <summary>
        /// Moves and/or resizes a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        // Token: 0x06000149 RID: 329 RVA: 0x000031C3 File Offset: 0x000013C3
        public static int WinMove(IntPtr winHandle, int x, int y, int width = -1, int height = -1)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinMoveByHandle64(winHandle, x, y, width, height);
            }
            return AutoItX_DLLImport.AU3_WinMoveByHandle32(winHandle, x, y, width, height);
        }

        /// <summary>
        /// Change a window's "Always On Top" attribute.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        // Token: 0x0600014A RID: 330 RVA: 0x000031E3 File Offset: 0x000013E3
        public static int WinSetOnTop(string title, string text, int flag)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetOnTop64(title, text, flag);
            }
            return AutoItX_DLLImport.AU3_WinSetOnTop32(title, text, flag);
        }

        /// <summary>
        /// Change a window's "Always On Top" attribute.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        // Token: 0x0600014B RID: 331 RVA: 0x000031FD File Offset: 0x000013FD
        public static int WinSetOnTop(IntPtr winHandle, int flag)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetOnTopByHandle64(winHandle, flag);
            }
            return AutoItX_DLLImport.AU3_WinSetOnTopByHandle32(winHandle, flag);
        }

        /// <summary>
        /// Shows, hides, minimizes, maximizes, or restores a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        // Token: 0x0600014C RID: 332 RVA: 0x00003215 File Offset: 0x00001415
        public static int WinSetState(string title, string text, int flags)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetState64(title, text, flags);
            }
            return AutoItX_DLLImport.AU3_WinSetState32(title, text, flags);
        }

        /// <summary>
        /// Shows, hides, minimizes, maximizes, or restores a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        // Token: 0x0600014D RID: 333 RVA: 0x0000322F File Offset: 0x0000142F
        public static int WinSetState(IntPtr winHandle, int flags)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetStateByHandle64(winHandle, flags);
            }
            return AutoItX_DLLImport.AU3_WinSetStateByHandle32(winHandle, flags);
        }

        /// <summary>
        /// Changes the title of a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="newTitle"></param>
        /// <returns></returns>
        // Token: 0x0600014E RID: 334 RVA: 0x00003247 File Offset: 0x00001447
        public static int WinSetTitle(string title, string text, string newTitle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTitle64(title, text, newTitle);
            }
            return AutoItX_DLLImport.AU3_WinSetTitle32(title, text, newTitle);
        }

        /// <summary>
        /// Changes the title of a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="newTitle"></param>
        /// <returns></returns>
        // Token: 0x0600014F RID: 335 RVA: 0x00003261 File Offset: 0x00001461
        public static int WinSetTitle(IntPtr winHandle, string newTitle)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTitleByHandle64(winHandle, newTitle);
            }
            return AutoItX_DLLImport.AU3_WinSetTitleByHandle32(winHandle, newTitle);
        }

        /// <summary>
        /// Sets the transparency of a window.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        // Token: 0x06000150 RID: 336 RVA: 0x00003279 File Offset: 0x00001479
        public static int WinSetTrans(string title, string text, int trans)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTrans64(title, text, trans);
            }
            return AutoItX_DLLImport.AU3_WinSetTrans32(title, text, trans);
        }

        /// <summary>
        /// Sets the transparency of a window.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        // Token: 0x06000151 RID: 337 RVA: 0x00003293 File Offset: 0x00001493
        public static int WinSetTrans(IntPtr winHandle, int trans)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTransByHandle64(winHandle, trans);
            }
            return AutoItX_DLLImport.AU3_WinSetTransByHandle32(winHandle, trans);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window exists.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000152 RID: 338 RVA: 0x000032AB File Offset: 0x000014AB
        public static int WinWait(string title = "", string text = "", int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWait64(title, text, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWait32(title, text, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window exists.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000153 RID: 339 RVA: 0x000032C5 File Offset: 0x000014C5
        public static int WinWait(IntPtr winHandle, int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitByHandle64(winHandle, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitByHandle32(winHandle, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window is active.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000154 RID: 340 RVA: 0x000032DD File Offset: 0x000014DD
        public static int WinWaitActive(string title = "", string text = "", int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitActive64(title, text, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitActive32(title, text, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window is active.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000155 RID: 341 RVA: 0x000032F7 File Offset: 0x000014F7
        public static int WinWaitActive(IntPtr winHandle, int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitActiveByHandle64(winHandle, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitActiveByHandle32(winHandle, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window does not exist.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000156 RID: 342 RVA: 0x0000330F File Offset: 0x0000150F
        public static int WinWaitClose(string title = "", string text = "", int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitClose64(title, text, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitClose32(title, text, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window does not exist.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000157 RID: 343 RVA: 0x00003329 File Offset: 0x00001529
        public static int WinWaitClose(IntPtr winHandle, int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitCloseByHandle64(winHandle, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitCloseByHandle32(winHandle, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window is not active.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000158 RID: 344 RVA: 0x00003341 File Offset: 0x00001541
        public static int WinWaitNotActive(string title = "", string text = "", int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitNotActive64(title, text, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitNotActive32(title, text, timeout);
        }

        /// <summary>
        /// Pauses execution of the script until the requested window is not active.
        /// </summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        // Token: 0x06000159 RID: 345 RVA: 0x0000335B File Offset: 0x0000155B
        public static int WinWaitNotActive(IntPtr winHandle, int timeout = 0)
        {
            if (AutoItX.Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle64(winHandle, timeout);
            }
            return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle32(winHandle, timeout);
        }

        // Token: 0x0600015A RID: 346 RVA: 0x00003373 File Offset: 0x00001573
        private static bool Is64Bit()
        {
            return Marshal.SizeOf(IntPtr.Zero) != 4;
        }

        /// <summary>
        /// Default value for _some_ int parameters (largest negative number).
        /// </summary>
        // Token: 0x04000009 RID: 9
        public const int INTDEFAULT = -2147483647;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000A RID: 10
        public const int SW_HIDE = 0;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000B RID: 11
        public const int SW_SHOWNORMAL = 1;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000C RID: 12
        public const int SW_NORMAL = 1;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000D RID: 13
        public const int SW_SHOWMINIMIZED = 2;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000E RID: 14
        public const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x0400000F RID: 15
        public const int SW_MAXIMIZE = 3;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000010 RID: 16
        public const int SW_SHOWNOACTIVATE = 4;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000011 RID: 17
        public const int SW_SHOW = 5;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000012 RID: 18
        public const int SW_MINIMIZE = 6;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000013 RID: 19
        public const int SW_SHOWMINNOACTIVE = 7;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000014 RID: 20
        public const int SW_SHOWNA = 8;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000015 RID: 21
        public const int SW_RESTORE = 9;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000016 RID: 22
        public const int SW_SHOWDEFAULT = 10;

        /// <summary>
        ///
        /// </summary>
        // Token: 0x04000017 RID: 23
        public const int SW_FORCEMINIMIZE = 11;

        // Token: 0x04000018 RID: 24
        private const int StringSizePath = 260;

        // Token: 0x04000019 RID: 25
        private const int StringSizeSmall = 1024;

        // Token: 0x0400001A RID: 26
        private const int StringSizeMedium = 65535;

        // Token: 0x0400001B RID: 27
        private const int StringSizeLarge = 1048576;
    }
    internal static class AutoItX_DLLImport
    {
        public const string AutoIt86 = "C:\\Windows\\AutoItX3.dll";
        public const string AutoIt64 = "C:\\Windows\\AutoItX3_x64.dll";
        // Token: 0x06000001 RID: 1
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Init", SetLastError = true)]
        internal static extern void AU3_Init32();

        // Token: 0x06000002 RID: 2
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Init", SetLastError = true)]
        internal static extern void AU3_Init64();

        // Token: 0x06000003 RID: 3
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_error", SetLastError = true)]
        internal static extern int AU3_error32();

        // Token: 0x06000004 RID: 4
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_error", SetLastError = true)]
        internal static extern int AU3_error64();

        // Token: 0x06000005 RID: 5
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_AutoItSetOption", SetLastError = true)]
        internal static extern int AU3_AutoItSetOption32([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

        // Token: 0x06000006 RID: 6
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_AutoItSetOption", SetLastError = true)]
        internal static extern int AU3_AutoItSetOption64([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

        // Token: 0x06000007 RID: 7
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ClipGet", SetLastError = true)]
        internal static extern void AU3_ClipGet32([MarshalAs(UnmanagedType.LPWStr)] StringBuilder clip, int bufSize);

        // Token: 0x06000008 RID: 8
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ClipGet", SetLastError = true)]
        internal static extern void AU3_ClipGet64([MarshalAs(UnmanagedType.LPWStr)] StringBuilder clip, int bufSize);

        // Token: 0x06000009 RID: 9
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ClipPut", SetLastError = true)]
        internal static extern void AU3_ClipPut32([MarshalAs(UnmanagedType.LPWStr)] string clip);

        // Token: 0x0600000A RID: 10
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ClipPut", SetLastError = true)]
        internal static extern void AU3_ClipPut64([MarshalAs(UnmanagedType.LPWStr)] string clip);

        // Token: 0x0600000B RID: 11
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClick", SetLastError = true)]
        internal static extern int AU3_ControlClick32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

        // Token: 0x0600000C RID: 12
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClick", SetLastError = true)]
        internal static extern int AU3_ControlClick64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

        // Token: 0x0600000D RID: 13
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClickByHandle", SetLastError = true)]
        internal static extern int AU3_ControlClickByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

        // Token: 0x0600000E RID: 14
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClickByHandle", SetLastError = true)]
        internal static extern int AU3_ControlClickByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

        // Token: 0x0600000F RID: 15
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommand", SetLastError = true)]
        internal static extern void AU3_ControlCommand32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000010 RID: 16
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommand", SetLastError = true)]
        internal static extern void AU3_ControlCommand64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000011 RID: 17
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommandByHandle", SetLastError = true)]
        internal static extern void AU3_ControlCommandByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000012 RID: 18
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommandByHandle", SetLastError = true)]
        internal static extern void AU3_ControlCommandByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000013 RID: 19
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListView", SetLastError = true)]
        internal static extern void AU3_ControlListView32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000014 RID: 20
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListView", SetLastError = true)]
        internal static extern void AU3_ControlListView64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000015 RID: 21
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListViewByHandle", SetLastError = true)]
        internal static extern void AU3_ControlListViewByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000016 RID: 22
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListViewByHandle", SetLastError = true)]
        internal static extern void AU3_ControlListViewByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000017 RID: 23
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisable", SetLastError = true)]
        internal static extern int AU3_ControlDisable32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000018 RID: 24
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisable", SetLastError = true)]
        internal static extern int AU3_ControlDisable64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000019 RID: 25
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisableByHandle", SetLastError = true)]
        internal static extern int AU3_ControlDisableByHandle32(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x0600001A RID: 26
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisableByHandle", SetLastError = true)]
        internal static extern int AU3_ControlDisableByHandle64(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x0600001B RID: 27
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnable", SetLastError = true)]
        internal static extern int AU3_ControlEnable32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x0600001C RID: 28
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnable", SetLastError = true)]
        internal static extern int AU3_ControlEnable64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x0600001D RID: 29
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnableByHandle", SetLastError = true)]
        internal static extern int AU3_ControlEnableByHandle32(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x0600001E RID: 30
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnableByHandle", SetLastError = true)]
        internal static extern int AU3_ControlEnableByHandle64(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x0600001F RID: 31
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocus", SetLastError = true)]
        internal static extern int AU3_ControlFocus32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000020 RID: 32
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocus", SetLastError = true)]
        internal static extern int AU3_ControlFocus64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000021 RID: 33
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocusByHandle", SetLastError = true)]
        internal static extern int AU3_ControlFocusByHandle32(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000022 RID: 34
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocusByHandle", SetLastError = true)]
        internal static extern int AU3_ControlFocusByHandle64(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000023 RID: 35
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocus", SetLastError = true)]
        internal static extern void AU3_ControlGetFocus32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

        // Token: 0x06000024 RID: 36
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocus", SetLastError = true)]
        internal static extern void AU3_ControlGetFocus64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

        // Token: 0x06000025 RID: 37
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocusByHandle", SetLastError = true)]
        internal static extern void AU3_ControlGetFocusByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

        // Token: 0x06000026 RID: 38
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocusByHandle", SetLastError = true)]
        internal static extern void AU3_ControlGetFocusByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

        // Token: 0x06000027 RID: 39
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandle", SetLastError = true)]
        internal static extern IntPtr AU3_ControlGetHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000028 RID: 40
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandle", SetLastError = true)]
        internal static extern IntPtr AU3_ControlGetHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000029 RID: 41
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandleAsText", SetLastError = true)]
        internal static extern void AU3_ControlGetHandleAsText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600002A RID: 42
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandleAsText", SetLastError = true)]
        internal static extern void AU3_ControlGetHandleAsText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600002B RID: 43
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPos", SetLastError = true)]
        internal static extern int AU3_ControlGetPos32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x0600002C RID: 44
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPos", SetLastError = true)]
        internal static extern int AU3_ControlGetPos64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x0600002D RID: 45
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPosByHandle", SetLastError = true)]
        internal static extern int AU3_ControlGetPosByHandle32(IntPtr winHandle, IntPtr controlHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x0600002E RID: 46
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPosByHandle", SetLastError = true)]
        internal static extern int AU3_ControlGetPosByHandle64(IntPtr winHandle, IntPtr controlHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x0600002F RID: 47
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetText", SetLastError = true)]
        internal static extern void AU3_ControlGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

        // Token: 0x06000030 RID: 48
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetText", SetLastError = true)]
        internal static extern void AU3_ControlGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

        // Token: 0x06000031 RID: 49
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_ControlGetTextByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

        // Token: 0x06000032 RID: 50
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_ControlGetTextByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

        // Token: 0x06000033 RID: 51
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHide", SetLastError = true)]
        internal static extern int AU3_ControlHide32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000034 RID: 52
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHide", SetLastError = true)]
        internal static extern int AU3_ControlHide64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000035 RID: 53
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHideByHandle", SetLastError = true)]
        internal static extern int AU3_ControlHideByHandle32(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000036 RID: 54
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHideByHandle", SetLastError = true)]
        internal static extern int AU3_ControlHideByHandle64(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000037 RID: 55
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMove", SetLastError = true)]
        internal static extern int AU3_ControlMove32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, int x, int y, int width, int height);

        // Token: 0x06000038 RID: 56
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMove", SetLastError = true)]
        internal static extern int AU3_ControlMove64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, int x, int y, int width, int height);

        // Token: 0x06000039 RID: 57
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMoveByHandle", SetLastError = true)]
        internal static extern int AU3_ControlMoveByHandle32(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width, int height);

        // Token: 0x0600003A RID: 58
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMoveByHandle", SetLastError = true)]
        internal static extern int AU3_ControlMoveByHandle64(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width, int height);

        // Token: 0x0600003B RID: 59
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSend", SetLastError = true)]
        internal static extern int AU3_ControlSend32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600003C RID: 60
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSend", SetLastError = true)]
        internal static extern int AU3_ControlSend64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600003D RID: 61
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSendByHandle", SetLastError = true)]
        internal static extern int AU3_ControlSendByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600003E RID: 62
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSendByHandle", SetLastError = true)]
        internal static extern int AU3_ControlSendByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600003F RID: 63
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetText", SetLastError = true)]
        internal static extern int AU3_ControlSetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

        // Token: 0x06000040 RID: 64
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetText", SetLastError = true)]
        internal static extern int AU3_ControlSetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

        // Token: 0x06000041 RID: 65
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetTextByHandle", SetLastError = true)]
        internal static extern int AU3_ControlSetTextByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

        // Token: 0x06000042 RID: 66
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetTextByHandle", SetLastError = true)]
        internal static extern int AU3_ControlSetTextByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

        // Token: 0x06000043 RID: 67
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShow", SetLastError = true)]
        internal static extern int AU3_ControlShow32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000044 RID: 68
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShow", SetLastError = true)]
        internal static extern int AU3_ControlShow64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

        // Token: 0x06000045 RID: 69
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShowByHandle", SetLastError = true)]
        internal static extern int AU3_ControlShowByHandle32(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000046 RID: 70
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShowByHandle", SetLastError = true)]
        internal static extern int AU3_ControlShowByHandle64(IntPtr winHandle, IntPtr controlHandle);

        // Token: 0x06000047 RID: 71
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeView", SetLastError = true)]
        internal static extern void AU3_ControlTreeView32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000048 RID: 72
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeView", SetLastError = true)]
        internal static extern void AU3_ControlTreeView64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x06000049 RID: 73
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeViewByHandle", SetLastError = true)]
        internal static extern void AU3_ControlTreeViewByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x0600004A RID: 74
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeViewByHandle", SetLastError = true)]
        internal static extern void AU3_ControlTreeViewByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x0600004B RID: 75
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapAdd", SetLastError = true)]
        internal static extern void AU3_DriveMapAdd32([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] string share, int flags, [MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string pwd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x0600004C RID: 76
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapAdd", SetLastError = true)]
        internal static extern void AU3_DriveMapAdd64([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] string share, int flags, [MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string pwd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

        // Token: 0x0600004D RID: 77
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapDel", SetLastError = true)]
        internal static extern int AU3_DriveMapDel32([MarshalAs(UnmanagedType.LPWStr)] string device);

        // Token: 0x0600004E RID: 78
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapDel", SetLastError = true)]
        internal static extern int AU3_DriveMapDel64([MarshalAs(UnmanagedType.LPWStr)] string device);

        // Token: 0x0600004F RID: 79
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapGet", SetLastError = true)]
        internal static extern void AU3_DriveMapGet32([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder mapping, int bufSize);

        // Token: 0x06000050 RID: 80
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapGet", SetLastError = true)]
        internal static extern void AU3_DriveMapGet64([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder mapping, int bufSize);

        // Token: 0x06000051 RID: 81
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_IsAdmin", SetLastError = true)]
        internal static extern int AU3_IsAdmin32();

        // Token: 0x06000052 RID: 82
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_IsAdmin", SetLastError = true)]
        internal static extern int AU3_IsAdmin64();

        // Token: 0x06000053 RID: 83
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClick", SetLastError = true)]
        internal static extern int AU3_MouseClick32([MarshalAs(UnmanagedType.LPWStr)] string button, int x, int y, int clicks, int speed);

        // Token: 0x06000054 RID: 84
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClick", SetLastError = true)]
        internal static extern int AU3_MouseClick64([MarshalAs(UnmanagedType.LPWStr)] string button, int x, int y, int clicks, int speed);

        // Token: 0x06000055 RID: 85
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClickDrag", SetLastError = true)]
        internal static extern int AU3_MouseClickDrag32([MarshalAs(UnmanagedType.LPWStr)] string button, int x1, int y1, int x2, int y2, int speed);

        // Token: 0x06000056 RID: 86
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClickDrag", SetLastError = true)]
        internal static extern int AU3_MouseClickDrag64([MarshalAs(UnmanagedType.LPWStr)] string button, int x1, int y1, int x2, int y2, int speed);

        // Token: 0x06000057 RID: 87
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseDown", SetLastError = true)]
        internal static extern void AU3_MouseDown32([MarshalAs(UnmanagedType.LPWStr)] string button);

        // Token: 0x06000058 RID: 88
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseDown", SetLastError = true)]
        internal static extern void AU3_MouseDown64([MarshalAs(UnmanagedType.LPWStr)] string button);

        // Token: 0x06000059 RID: 89
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetCursor", SetLastError = true)]
        internal static extern int AU3_MouseGetCursor32();

        // Token: 0x0600005A RID: 90
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetCursor", SetLastError = true)]
        internal static extern int AU3_MouseGetCursor64();

        // Token: 0x0600005B RID: 91
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetPos", SetLastError = true)]
        internal static extern void AU3_MouseGetPos32(ref AutoItX_DLLImport.POINT pt);

        // Token: 0x0600005C RID: 92
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetPos", SetLastError = true)]
        internal static extern void AU3_MouseGetPos64(ref AutoItX_DLLImport.POINT pt);

        // Token: 0x0600005D RID: 93
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseMove", SetLastError = true)]
        internal static extern int AU3_MouseMove32(int x, int y, int speed);

        // Token: 0x0600005E RID: 94
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseMove", SetLastError = true)]
        internal static extern int AU3_MouseMove64(int x, int y, int speed);

        // Token: 0x0600005F RID: 95
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseUp", SetLastError = true)]
        internal static extern void AU3_MouseUp32([MarshalAs(UnmanagedType.LPWStr)] string button);

        // Token: 0x06000060 RID: 96
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseUp", SetLastError = true)]
        internal static extern void AU3_MouseUp64([MarshalAs(UnmanagedType.LPWStr)] string button);

        // Token: 0x06000061 RID: 97
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseWheel", SetLastError = true)]
        internal static extern void AU3_MouseWheel32([MarshalAs(UnmanagedType.LPWStr)] string direction, int clicks);

        // Token: 0x06000062 RID: 98
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_MouseWheel", SetLastError = true)]
        internal static extern void AU3_MouseWheel64([MarshalAs(UnmanagedType.LPWStr)] string direction, int clicks);

        // Token: 0x06000063 RID: 99
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Opt", SetLastError = true)]
        internal static extern int AU3_Opt32([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

        // Token: 0x06000064 RID: 100
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Opt", SetLastError = true)]
        internal static extern int AU3_Opt64([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

        // Token: 0x06000065 RID: 101
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelChecksum", SetLastError = true)]
        internal static extern uint AU3_PixelChecksum32(ref AutoItX_DLLImport.RECT rect, int step);

        // Token: 0x06000066 RID: 102
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelChecksum", SetLastError = true)]
        internal static extern uint AU3_PixelChecksum64(ref AutoItX_DLLImport.RECT rect, int step);

        // Token: 0x06000067 RID: 103
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelGetColor", SetLastError = true)]
        internal static extern int AU3_PixelGetColor32(int x, int y);

        // Token: 0x06000068 RID: 104
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelGetColor", SetLastError = true)]
        internal static extern int AU3_PixelGetColor64(int x, int y);

        // Token: 0x06000069 RID: 105
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelSearch", SetLastError = true)]
        internal static extern void AU3_PixelSearch32(ref AutoItX_DLLImport.RECT rect, int color, int shade, int step, ref AutoItX_DLLImport.POINT winPoint);

        // Token: 0x0600006A RID: 106
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_PixelSearch", SetLastError = true)]
        internal static extern void AU3_PixelSearch64(ref AutoItX_DLLImport.RECT rect, int color, int shade, int step, ref AutoItX_DLLImport.POINT winPoint);

        // Token: 0x0600006B RID: 107
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessClose", SetLastError = true)]
        internal static extern int AU3_ProcessClose32([MarshalAs(UnmanagedType.LPWStr)] string process);

        // Token: 0x0600006C RID: 108
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessClose", SetLastError = true)]
        internal static extern int AU3_ProcessClose64([MarshalAs(UnmanagedType.LPWStr)] string process);

        // Token: 0x0600006D RID: 109
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessExists", SetLastError = true)]
        internal static extern int AU3_ProcessExists32([MarshalAs(UnmanagedType.LPWStr)] string process);

        // Token: 0x0600006E RID: 110
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessExists", SetLastError = true)]
        internal static extern int AU3_ProcessExists64([MarshalAs(UnmanagedType.LPWStr)] string process);

        // Token: 0x0600006F RID: 111
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessSetPriority", SetLastError = true)]
        internal static extern int AU3_ProcessSetPriority32([MarshalAs(UnmanagedType.LPWStr)] string process, int priority);

        // Token: 0x06000070 RID: 112
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessSetPriority", SetLastError = true)]
        internal static extern int AU3_ProcessSetPriority64([MarshalAs(UnmanagedType.LPWStr)] string process, int priority);

        // Token: 0x06000071 RID: 113
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWait", SetLastError = true)]
        internal static extern int AU3_ProcessWait32([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

        // Token: 0x06000072 RID: 114
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWait", SetLastError = true)]
        internal static extern int AU3_ProcessWait64([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

        // Token: 0x06000073 RID: 115
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWaitClose", SetLastError = true)]
        internal static extern int AU3_ProcessWaitClose32([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

        // Token: 0x06000074 RID: 116
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWaitClose", SetLastError = true)]
        internal static extern int AU3_ProcessWaitClose64([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

        // Token: 0x06000075 RID: 117
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Run", SetLastError = true)]
        internal static extern int AU3_Run32([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x06000076 RID: 118
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Run", SetLastError = true)]
        internal static extern int AU3_Run64([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x06000077 RID: 119
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_RunAs", SetLastError = true)]
        internal static extern int AU3_RunAs32([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x06000078 RID: 120
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_RunAs", SetLastError = true)]
        internal static extern int AU3_RunAs64([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x06000079 RID: 121
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_RunAsWait", SetLastError = true)]
        internal static extern int AU3_RunAsWait32([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x0600007A RID: 122
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_RunAsWait", SetLastError = true)]
        internal static extern int AU3_RunAsWait64([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x0600007B RID: 123
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_RunWait", SetLastError = true)]
        internal static extern int AU3_RunWait32([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x0600007C RID: 124
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_RunWait", SetLastError = true)]
        internal static extern int AU3_RunWait64([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

        // Token: 0x0600007D RID: 125
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Send", SetLastError = true)]
        internal static extern void AU3_Send32([MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600007E RID: 126
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Send", SetLastError = true)]
        internal static extern void AU3_Send64([MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

        // Token: 0x0600007F RID: 127
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Shutdown", SetLastError = true)]
        internal static extern int AU3_Shutdown32(int flags);

        // Token: 0x06000080 RID: 128
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Shutdown", SetLastError = true)]
        internal static extern int AU3_Shutdown64(int flags);

        // Token: 0x06000081 RID: 129
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_Sleep", SetLastError = true)]
        internal static extern void AU3_Sleep32(int milliseconds);

        // Token: 0x06000082 RID: 130
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_Sleep", SetLastError = true)]
        internal static extern void AU3_Sleep64(int milliseconds);

        // Token: 0x06000083 RID: 131
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetText", SetLastError = true)]
        internal static extern void AU3_StatusbarGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

        // Token: 0x06000084 RID: 132
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetText", SetLastError = true)]
        internal static extern void AU3_StatusbarGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

        // Token: 0x06000085 RID: 133
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_StatusbarGetTextByHandle32(IntPtr winHandle, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

        // Token: 0x06000086 RID: 134
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_StatusbarGetTextByHandle64(IntPtr winHandle, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

        // Token: 0x06000087 RID: 135
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_ToolTip", SetLastError = true)]
        internal static extern void AU3_ToolTip32([MarshalAs(UnmanagedType.LPWStr)] string tip, int x, int y);

        // Token: 0x06000088 RID: 136
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_ToolTip", SetLastError = true)]
        internal static extern void AU3_ToolTip64([MarshalAs(UnmanagedType.LPWStr)] string tip, int x, int y);

        // Token: 0x06000089 RID: 137
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivate", SetLastError = true)]
        internal static extern int AU3_WinActivate32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x0600008A RID: 138
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivate", SetLastError = true)]
        internal static extern int AU3_WinActivate64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x0600008B RID: 139
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivateByHandle", SetLastError = true)]
        internal static extern int AU3_WinActivateByHandle32(IntPtr winHandle);

        // Token: 0x0600008C RID: 140
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivateByHandle", SetLastError = true)]
        internal static extern int AU3_WinActivateByHandle64(IntPtr winHandle);

        // Token: 0x0600008D RID: 141
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActive", SetLastError = true)]
        internal static extern int AU3_WinActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x0600008E RID: 142
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActive", SetLastError = true)]
        internal static extern int AU3_WinActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x0600008F RID: 143
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinActiveByHandle32(IntPtr winHandle);

        // Token: 0x06000090 RID: 144
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinActiveByHandle64(IntPtr winHandle);

        // Token: 0x06000091 RID: 145
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinClose", SetLastError = true)]
        internal static extern int AU3_WinClose32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x06000092 RID: 146
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinClose", SetLastError = true)]
        internal static extern int AU3_WinClose64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x06000093 RID: 147
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinCloseByHandle", SetLastError = true)]
        internal static extern int AU3_WinCloseByHandle32(IntPtr winHandle);

        // Token: 0x06000094 RID: 148
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinCloseByHandle", SetLastError = true)]
        internal static extern int AU3_WinCloseByHandle64(IntPtr winHandle);

        // Token: 0x06000095 RID: 149
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinExists", SetLastError = true)]
        internal static extern int AU3_WinExists32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x06000096 RID: 150
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinExists", SetLastError = true)]
        internal static extern int AU3_WinExists64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x06000097 RID: 151
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinExistsByHandle", SetLastError = true)]
        internal static extern int AU3_WinExistsByHandle32(IntPtr winHandle);

        // Token: 0x06000098 RID: 152
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinExistsByHandle", SetLastError = true)]
        internal static extern int AU3_WinExistsByHandle64(IntPtr winHandle);

        // Token: 0x06000099 RID: 153
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetCaretPos", SetLastError = true)]
        internal static extern int AU3_WinGetCaretPos32(out AutoItX_DLLImport.POINT pt);

        // Token: 0x0600009A RID: 154
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetCaretPos", SetLastError = true)]
        internal static extern int AU3_WinGetCaretPos64(out AutoItX_DLLImport.POINT pt);

        // Token: 0x0600009B RID: 155
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassList", SetLastError = true)]
        internal static extern void AU3_WinGetClassList32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600009C RID: 156
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassList", SetLastError = true)]
        internal static extern void AU3_WinGetClassList64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600009D RID: 157
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassListByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetClassListByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600009E RID: 158
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassListByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetClassListByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x0600009F RID: 159
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSize", SetLastError = true)]
        internal static extern int AU3_WinGetClientSize32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A0 RID: 160
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSize", SetLastError = true)]
        internal static extern int AU3_WinGetClientSize64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A1 RID: 161
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSizeByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetClientSizeByHandle32(IntPtr winHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A2 RID: 162
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSizeByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetClientSizeByHandle64(IntPtr winHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A3 RID: 163
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandle", SetLastError = true)]
        internal static extern IntPtr AU3_WinGetHandle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000A4 RID: 164
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandle", SetLastError = true)]
        internal static extern IntPtr AU3_WinGetHandle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000A5 RID: 165
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandleAsText", SetLastError = true)]
        internal static extern void AU3_WinGetHandleAsText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000A6 RID: 166
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandleAsText", SetLastError = true)]
        internal static extern void AU3_WinGetHandleAsText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000A7 RID: 167
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPos", SetLastError = true)]
        internal static extern int AU3_WinGetPos32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A8 RID: 168
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPos", SetLastError = true)]
        internal static extern int AU3_WinGetPos64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000A9 RID: 169
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPosByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetPosByHandle32(IntPtr winHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000AA RID: 170
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPosByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetPosByHandle64(IntPtr winHandle, ref AutoItX_DLLImport.RECT rect);

        // Token: 0x060000AB RID: 171
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcess", SetLastError = true)]
        internal static extern uint AU3_WinGetProcess32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000AC RID: 172
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcess", SetLastError = true)]
        internal static extern uint AU3_WinGetProcess64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000AD RID: 173
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcessByHandle", SetLastError = true)]
        internal static extern uint AU3_WinGetProcessByHandle32(IntPtr winHandle);

        // Token: 0x060000AE RID: 174
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcessByHandle", SetLastError = true)]
        internal static extern uint AU3_WinGetProcessByHandle64(IntPtr winHandle);

        // Token: 0x060000AF RID: 175
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetState", SetLastError = true)]
        internal static extern int AU3_WinGetState32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000B0 RID: 176
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetState", SetLastError = true)]
        internal static extern int AU3_WinGetState64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000B1 RID: 177
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetStateByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetStateByHandle32(IntPtr winHandle);

        // Token: 0x060000B2 RID: 178
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetStateByHandle", SetLastError = true)]
        internal static extern int AU3_WinGetStateByHandle64(IntPtr winHandle);

        // Token: 0x060000B3 RID: 179
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetText", SetLastError = true)]
        internal static extern void AU3_WinGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B4 RID: 180
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetText", SetLastError = true)]
        internal static extern void AU3_WinGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B5 RID: 181
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetTextByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B6 RID: 182
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTextByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetTextByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B7 RID: 183
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitle", SetLastError = true)]
        internal static extern void AU3_WinGetTitle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B8 RID: 184
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitle", SetLastError = true)]
        internal static extern void AU3_WinGetTitle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000B9 RID: 185
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitleByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetTitleByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000BA RID: 186
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitleByHandle", SetLastError = true)]
        internal static extern void AU3_WinGetTitleByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

        // Token: 0x060000BB RID: 187
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinKill", SetLastError = true)]
        internal static extern int AU3_WinKill32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000BC RID: 188
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinKill", SetLastError = true)]
        internal static extern int AU3_WinKill64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

        // Token: 0x060000BD RID: 189
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinKillByHandle", SetLastError = true)]
        internal static extern int AU3_WinKillByHandle32(IntPtr winHandle);

        // Token: 0x060000BE RID: 190
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinKillByHandle", SetLastError = true)]
        internal static extern int AU3_WinKillByHandle64(IntPtr winHandle);

        // Token: 0x060000BF RID: 191
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMenuSelectItem", SetLastError = true)]
        internal static extern int AU3_WinMenuSelectItem32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string item1, [MarshalAs(UnmanagedType.LPWStr)] string item2, [MarshalAs(UnmanagedType.LPWStr)] string item3, [MarshalAs(UnmanagedType.LPWStr)] string item4, [MarshalAs(UnmanagedType.LPWStr)] string item5, [MarshalAs(UnmanagedType.LPWStr)] string item6, [MarshalAs(UnmanagedType.LPWStr)] string item7, [MarshalAs(UnmanagedType.LPWStr)] string item8);

        // Token: 0x060000C0 RID: 192
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAll", SetLastError = true)]
        internal static extern void AU3_WinMinimizeAll32();

        // Token: 0x060000C1 RID: 193
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAll", SetLastError = true)]
        internal static extern void AU3_WinMinimizeAll64();

        // Token: 0x060000C2 RID: 194
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAllUndo", SetLastError = true)]
        internal static extern void AU3_WinMinimizeAllUndo32();

        // Token: 0x060000C3 RID: 195
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAllUndo", SetLastError = true)]
        internal static extern void AU3_WinMinimizeAllUndo64();

        // Token: 0x060000C4 RID: 196
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMove", SetLastError = true)]
        internal static extern int AU3_WinMove32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int x, int y, int width, int height);

        // Token: 0x060000C5 RID: 197
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMove", SetLastError = true)]
        internal static extern int AU3_WinMove64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int x, int y, int width, int height);

        // Token: 0x060000C6 RID: 198
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMoveByHandle", SetLastError = true)]
        internal static extern int AU3_WinMoveByHandle32(IntPtr winHandle, int x, int y, int width, int height);

        // Token: 0x060000C7 RID: 199
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinMoveByHandle", SetLastError = true)]
        internal static extern int AU3_WinMoveByHandle64(IntPtr winHandle, int x, int y, int width, int height);

        // Token: 0x060000C8 RID: 200
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTop", SetLastError = true)]
        internal static extern int AU3_WinSetOnTop32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flag);

        // Token: 0x060000C9 RID: 201
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTop", SetLastError = true)]
        internal static extern int AU3_WinSetOnTop64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flag);

        // Token: 0x060000CA RID: 202
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTopByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetOnTopByHandle32(IntPtr winHandle, int flag);

        // Token: 0x060000CB RID: 203
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTopByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetOnTopByHandle64(IntPtr winHandle, int flag);

        // Token: 0x060000CC RID: 204
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetState", SetLastError = true)]
        internal static extern int AU3_WinSetState32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flags);

        // Token: 0x060000CD RID: 205
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetState", SetLastError = true)]
        internal static extern int AU3_WinSetState64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flags);

        // Token: 0x060000CE RID: 206
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetStateByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetStateByHandle32(IntPtr winHandle, int flags);

        // Token: 0x060000CF RID: 207
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetStateByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetStateByHandle64(IntPtr winHandle, int flags);

        // Token: 0x060000D0 RID: 208
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitle", SetLastError = true)]
        internal static extern int AU3_WinSetTitle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

        // Token: 0x060000D1 RID: 209
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitle", SetLastError = true)]
        internal static extern int AU3_WinSetTitle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

        // Token: 0x060000D2 RID: 210
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitleByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetTitleByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

        // Token: 0x060000D3 RID: 211
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitleByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetTitleByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

        // Token: 0x060000D4 RID: 212
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTrans", SetLastError = true)]
        internal static extern int AU3_WinSetTrans32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int trans);

        // Token: 0x060000D5 RID: 213
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTrans", SetLastError = true)]
        internal static extern int AU3_WinSetTrans64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int trans);

        // Token: 0x060000D6 RID: 214
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTransByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetTransByHandle32(IntPtr winHandle, int trans);

        // Token: 0x060000D7 RID: 215
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTransByHandle", SetLastError = true)]
        internal static extern int AU3_WinSetTransByHandle64(IntPtr winHandle, int trans);

        // Token: 0x060000D8 RID: 216
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWait", SetLastError = true)]
        internal static extern int AU3_WinWait32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000D9 RID: 217
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWait", SetLastError = true)]
        internal static extern int AU3_WinWait64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000DA RID: 218
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitByHandle32(IntPtr winHandle, int timeout);

        // Token: 0x060000DB RID: 219
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitByHandle64(IntPtr winHandle, int timeout);

        // Token: 0x060000DC RID: 220
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActive", SetLastError = true)]
        internal static extern int AU3_WinWaitActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000DD RID: 221
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActive", SetLastError = true)]
        internal static extern int AU3_WinWaitActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000DE RID: 222
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitActiveByHandle32(IntPtr winHandle, int timeout);

        // Token: 0x060000DF RID: 223
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitActiveByHandle64(IntPtr winHandle, int timeout);

        // Token: 0x060000E0 RID: 224
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitClose", SetLastError = true)]
        internal static extern int AU3_WinWaitClose32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000E1 RID: 225
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitClose", SetLastError = true)]
        internal static extern int AU3_WinWaitClose64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000E2 RID: 226
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitCloseByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitCloseByHandle32(IntPtr winHandle, int timeout);

        // Token: 0x060000E3 RID: 227
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitCloseByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitCloseByHandle64(IntPtr winHandle, int timeout);

        // Token: 0x060000E4 RID: 228
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActive", SetLastError = true)]
        internal static extern int AU3_WinWaitNotActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000E5 RID: 229
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActive", SetLastError = true)]
        internal static extern int AU3_WinWaitNotActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

        // Token: 0x060000E6 RID: 230
        [DllImport(AutoIt86, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitNotActiveByHandle32(IntPtr winHandle, int timeout);

        // Token: 0x060000E7 RID: 231
        [DllImport(AutoIt64, CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActiveByHandle", SetLastError = true)]
        internal static extern int AU3_WinWaitNotActiveByHandle64(IntPtr winHandle, int timeout);

        // Token: 0x04000001 RID: 1
        private const string AUTOITXDLL_x86 = AutoIt86;

        // Token: 0x04000002 RID: 2
        private const string AUTOITXDLL_x64 = AutoIt64;

        // Token: 0x02000003 RID: 3
        internal struct RECT
        {
            // Token: 0x04000003 RID: 3
            public int left;

            // Token: 0x04000004 RID: 4
            public int top;

            // Token: 0x04000005 RID: 5
            public int right;

            // Token: 0x04000006 RID: 6
            public int bottom;
        }

        // Token: 0x02000004 RID: 4
        internal struct POINT
        {
            // Token: 0x04000007 RID: 7
            public int x;

            // Token: 0x04000008 RID: 8
            public int y;
        }
    }
}
