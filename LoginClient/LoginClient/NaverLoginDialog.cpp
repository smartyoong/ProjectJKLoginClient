// NaverLoginDialog.cpp: 구현 파일
//

#include "pch.h"
#include "LoginClient.h"
#include "NaverLoginDialog.h"


// NaverLoginDialog 대화 상자

IMPLEMENT_DYNCREATE(NaverLoginDialog, CDHtmlDialog)

NaverLoginDialog::NaverLoginDialog(CWnd* pParent /*=nullptr*/)
	: CDHtmlDialog(IDD_NaverLoginDialog, 104, pParent)
{

}

NaverLoginDialog::~NaverLoginDialog()
{
}

void NaverLoginDialog::DoDataExchange(CDataExchange* pDX)
{
	CDHtmlDialog::DoDataExchange(pDX);
}

BOOL NaverLoginDialog::OnInitDialog()
{
	CDHtmlDialog::OnInitDialog();
	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

BEGIN_MESSAGE_MAP(NaverLoginDialog, CDHtmlDialog)
END_MESSAGE_MAP()

BEGIN_DHTML_EVENT_MAP(NaverLoginDialog)
	DHTML_EVENT_ONCLICK(_T("ButtonOK"), OnButtonOK)
	DHTML_EVENT_ONCLICK(_T("ButtonCancel"), OnButtonCancel)
END_DHTML_EVENT_MAP()



// NaverLoginDialog 메시지 처리기

HRESULT NaverLoginDialog::OnButtonOK(IHTMLElement* /*pElement*/)
{
	OnOK();
	return S_OK;
}

HRESULT NaverLoginDialog::OnButtonCancel(IHTMLElement* /*pElement*/)
{
	OnCancel();
	return S_OK;
}