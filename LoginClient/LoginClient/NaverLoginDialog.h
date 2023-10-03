#pragma once

#ifdef _WIN32_WCE
#error "Windows CE에서는 CDHtmlDialog가 지원되지 않습니다."
#endif


// NaverLoginDialog 대화 상자

class NaverLoginDialog : public CDHtmlDialog
{
	DECLARE_DYNCREATE(NaverLoginDialog)

public:
	NaverLoginDialog(CWnd* pParent = nullptr);   // 표준 생성자입니다.
	virtual ~NaverLoginDialog();
// 재정의입니다.
	HRESULT OnButtonOK(IHTMLElement *pElement);
	HRESULT OnButtonCancel(IHTMLElement *pElement);

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_NaverLoginDialog, IDH = 104 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.
	virtual BOOL OnInitDialog();

	DECLARE_MESSAGE_MAP()
	DECLARE_DHTML_EVENT_MAP()
};
