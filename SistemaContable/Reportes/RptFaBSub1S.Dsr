VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptFaBSub1S 
   Caption         =   "SIGC - RptFaBSub1S (ActiveReport)"
   ClientHeight    =   10695
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15360
   ShowInTaskbar   =   0   'False
   _ExtentX        =   27093
   _ExtentY        =   18865
   SectionData     =   "RptFaBSub1S.dsx":0000
End
Attribute VB_Name = "RptFaBSub1S"
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

   CtrlCad txthis_articulo
   
   If CDec(Trim(txthis_cantidad.Text)) = 0 Then
      txthis_cantidad.Text = ""
      txthis_aliva.Text = ""
      txthis_punitario.Text = ""
      txthis_total.Text = ""
   End If
   
End Sub




