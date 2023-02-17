VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptFaBSub1 
   Caption         =   "SIGC - RptFaBSub1 (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   1485
   ClientWidth     =   15360
   ShowInTaskbar   =   0   'False
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptFaBSub1.dsx":0000
End
Attribute VB_Name = "RptFaBSub1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ActiveReport_ReportStart()
   If Len(ParCerosCant) > 0 Then
      txthis_cantidad.OutputFormat = "0." & ParCerosCant
   End If
End Sub

Private Sub Detail_BeforePrint()
   On Error Resume Next
   If txthis_codtex.Text = "0" Then txthis_codtex.Text = ""
   If txthis_codnum.Text = "88888888" Then
      txthis_codnum.Text = ""
      Field16.Text = ""
   End If
   txthis_dtoCondA = IIf((txthis_dtoCondA) = "", 0, txthis_dtoCondA)
   txthis_dtoCondB = IIf((txthis_dtoCondB) = "", 0, txthis_dtoCondB)
   txthis_dtoCondC = IIf((txthis_dtoCondC) = "", 0, txthis_dtoCondC)
   txthis_dtoCondD = IIf((txthis_dtoCondD) = "", 0, txthis_dtoCondD)
   txtDtos.Text = IIf((txthis_dtoa = 0), "", Format(txthis_dtoa, "0.00")) _
   & IIf((txthis_dtob = 0), "", " " & Format(txthis_dtob, "0.00")) _
   & IIf((txthis_dtoc = 0), "", " " & Format(txthis_dtoc, "0.00")) _
   & IIf((txthis_dtod = 0), "", " " & Format(txthis_dtod, "0.00")) _
   & IIf((txthis_dtoe = 0), "", " " & Format(txthis_dtoe, "0.00")) _
   & IIf((txthis_dtof = 0), "", " " & Format(txthis_dtof, "0.00")) _
   & IIf((txthis_dtoCondA = 0), "", " " & Format(txthis_dtoCondA, "0.00")) _
   & IIf((txthis_dtoCondB = 0), "", " " & Format(txthis_dtoCondB, "0.00")) _
   & IIf((txthis_dtoCondC = 0), "", " " & Format(txthis_dtoCondC, "0.00")) _
   & IIf((txthis_dtoCondD = 0), "", " " & Format(txthis_dtoCondD, "0.00")) _
   & IIf((txthis_dtoctdo = 0), "", " " & Format(txthis_dtoctdo, "0.00"))

   CtrlCad txthis_articulo
   
   If CDec(txthis_preclista) = 0 Then txthis_preclista.Text = ""

   If CDec(Trim(txthis_cantidad.Text)) = 0 Then
      txthis_cantidad.Text = ""
      txthis_aliva.Text = ""
      txthis_punitario.Text = ""
      txthis_total.Text = ""
      txthis_preclista.Text = ""
      txtDtos.Text = ""
   End If
End Sub


