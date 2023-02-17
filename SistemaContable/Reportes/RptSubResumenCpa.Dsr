VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptSubResumenCpa 
   Caption         =   "SIGC - RptSubResumenCpa (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptSubResumenCpa.dsx":0000
End
Attribute VB_Name = "RptSubResumenCpa"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   On Error Resume Next
   
   If txthis_codtex.Text = "0" And txt_his_codnum = "88888888" Then
      txthis_codtex.Text = ""
      txthis_codnum.Text = ""
   End If
   
   txtDtos.Text = IIf((txthis_dtoa = 0), "", Format(txthis_dtoa, "0")) _
   & IIf((txthis_dtob = 0), "", "-" & Format(txthis_dtob, "0")) _
   & IIf((txthis_dtoc = 0), "", "-" & Format(txthis_dtoc, "0")) _
   & IIf((txthis_dtod = 0), "", "-" & Format(txthis_dtod, "0")) _
   & IIf((txthis_dtoe = 0), "", "-" & Format(txthis_dtoe, "0")) _
   & IIf((txthis_dtof = 0), "", "-" & Format(txthis_dtof, "0"))

End Sub
