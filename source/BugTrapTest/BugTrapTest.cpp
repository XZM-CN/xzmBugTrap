
// BugTrapTest.cpp : 定义应用程序的类行为。
//

#include "stdafx.h"
#include "BugTrapTest.h"
#include "BugTrapTestDlg.h"

#include "../Client/BugTrap.h"

#if defined _M_IX86
#ifdef _MANAGED
#ifdef _DEBUG
#pragma comment(lib, "../../bin/BugTrap1.lib")      // Link to ANSI DLL
#else
#pragma comment(lib, "../../bin/BugTrap2.lib")  // Link to Unicode DLL
#endif
#else
#ifdef _DEBUG
#pragma comment(lib, "../../bin/BugTrapD_x86.lib")// Debug x86
#else
#pragma comment(lib, "../../bin/BugTrapR_x86.lib")// Release x86
#endif
#endif
#elif defined _M_X64
#ifdef _MANAGED
#ifdef _DEBUG
#pragma comment(lib, "../../bin/BugTrap5.lib")// 
#else
#pragma comment(lib, "../../bin/BugTrap6.lib")// 
#endif
#else
#ifdef _DEBUG
#pragma comment(lib, "../../bin/BugTrap7.lib")// 
#else
#pragma comment(lib, "../../bin/BugTrap8.lib")// 
#endif
#endif
#else
#error CPU architecture is not supported.
#endif




#ifdef _DEBUG
#define new DEBUG_NEW
#endif


static void SetupExceptionHandler()
{
	BT_InstallSehFilter();
	BT_SetAppName(_T("Your application name"));
	BT_SetSupportEMail(_T("your@email.com"));
	BT_SetFlags(BTF_DETAILEDMODE | BTF_EDITMAIL | BTF_ATTACHREPORT| BTF_SCREENCAPTURE);
	//BT_SetSupportServer(_T("localhost"), 9999);
	BT_SetSupportURL(_T("http://www.your-web-site.com"));
}


// CBugTrapTestApp

BEGIN_MESSAGE_MAP(CBugTrapTestApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CBugTrapTestApp 构造

CBugTrapTestApp::CBugTrapTestApp()
{
	// 支持重新启动管理器
	m_dwRestartManagerSupportFlags = AFX_RESTART_MANAGER_SUPPORT_RESTART;

	// TODO: 在此处添加构造代码，
	// 将所有重要的初始化放置在 InitInstance 中
}


// 唯一的一个 CBugTrapTestApp 对象

CBugTrapTestApp theApp;


// CBugTrapTestApp 初始化

BOOL CBugTrapTestApp::InitInstance()
{
	SetupExceptionHandler();
	// 如果一个运行在 Windows XP 上的应用程序清单指定要
	// 使用 ComCtl32.dll 版本 6 或更高版本来启用可视化方式，
	//则需要 InitCommonControlsEx()。否则，将无法创建窗口。
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// 将它设置为包括所有要在应用程序中使用的
	// 公共控件类。
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();


	AfxEnableControlContainer();

	// 创建 shell 管理器，以防对话框包含
	// 任何 shell 树视图控件或 shell 列表视图控件。
	CShellManager *pShellManager = new CShellManager;

	// 标准初始化
	// 如果未使用这些功能并希望减小
	// 最终可执行文件的大小，则应移除下列
	// 不需要的特定初始化例程
	// 更改用于存储设置的注册表项
	// TODO: 应适当修改该字符串，
	// 例如修改为公司或组织名
	SetRegistryKey(_T("应用程序向导生成的本地应用程序"));

	CBugTrapTestDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: 在此放置处理何时用
		//  “确定”来关闭对话框的代码
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: 在此放置处理何时用
		//  “取消”来关闭对话框的代码
	}

	// 删除上面创建的 shell 管理器。
	if (pShellManager != NULL)
	{
		delete pShellManager;
	}

	// 由于对话框已关闭，所以将返回 FALSE 以便退出应用程序，
	//  而不是启动应用程序的消息泵。
	return FALSE;
}

