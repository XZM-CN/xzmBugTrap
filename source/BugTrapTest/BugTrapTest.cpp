
// BugTrapTest.cpp : ����Ӧ�ó��������Ϊ��
//

#include "stdafx.h"
#include "BugTrapTest.h"
#include "BugTrapTestDlg.h"

#include "../Client/BugTrap.h"

#ifndef _DEBUG
#pragma comment(lib, "../../bin/BugTrapD.lib")      // Link to ANSI DLL
#else
#pragma comment(lib, "../../bin/BugTrap.lib")  // Link to Unicode DLL
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


// CBugTrapTestApp ����

CBugTrapTestApp::CBugTrapTestApp()
{
	// ֧����������������
	m_dwRestartManagerSupportFlags = AFX_RESTART_MANAGER_SUPPORT_RESTART;

	// TODO: �ڴ˴���ӹ�����룬
	// ��������Ҫ�ĳ�ʼ�������� InitInstance ��
}


// Ψһ��һ�� CBugTrapTestApp ����

CBugTrapTestApp theApp;


// CBugTrapTestApp ��ʼ��

BOOL CBugTrapTestApp::InitInstance()
{
	SetupExceptionHandler();
	// ���һ�������� Windows XP �ϵ�Ӧ�ó����嵥ָ��Ҫ
	// ʹ�� ComCtl32.dll �汾 6 ����߰汾�����ÿ��ӻ���ʽ��
	//����Ҫ InitCommonControlsEx()�����򣬽��޷��������ڡ�
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// ��������Ϊ��������Ҫ��Ӧ�ó�����ʹ�õ�
	// �����ؼ��ࡣ
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();


	AfxEnableControlContainer();

	// ���� shell ���������Է��Ի������
	// �κ� shell ����ͼ�ؼ��� shell �б���ͼ�ؼ���
	CShellManager *pShellManager = new CShellManager;

	// ��׼��ʼ��
	// ���δʹ����Щ���ܲ�ϣ����С
	// ���տ�ִ���ļ��Ĵ�С����Ӧ�Ƴ�����
	// ����Ҫ���ض���ʼ������
	// �������ڴ洢���õ�ע�����
	// TODO: Ӧ�ʵ��޸ĸ��ַ�����
	// �����޸�Ϊ��˾����֯��
	SetRegistryKey(_T("Ӧ�ó��������ɵı���Ӧ�ó���"));

	CBugTrapTestDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: �ڴ˷��ô����ʱ��
		//  ��ȷ�������رնԻ���Ĵ���
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: �ڴ˷��ô����ʱ��
		//  ��ȡ�������رնԻ���Ĵ���
	}

	// ɾ�����洴���� shell ��������
	if (pShellManager != NULL)
	{
		delete pShellManager;
	}

	// ���ڶԻ����ѹرգ����Խ����� FALSE �Ա��˳�Ӧ�ó���
	//  ����������Ӧ�ó������Ϣ�á�
	return FALSE;
}

