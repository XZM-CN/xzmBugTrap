
// BugTrapTest.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CBugTrapTestApp:
// �йش����ʵ�֣������ BugTrapTest.cpp
//

class CBugTrapTestApp : public CWinApp
{
public:
	CBugTrapTestApp();

// ��д
public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern CBugTrapTestApp theApp;