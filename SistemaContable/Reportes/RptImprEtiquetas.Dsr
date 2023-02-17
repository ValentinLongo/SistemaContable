VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptImprEtiquetas 
   Caption         =   "SIGC - RptImprEtiquetas (ActiveReport)"
   ClientHeight    =   11115
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15240
   _ExtentX        =   26882
   _ExtentY        =   19606
   SectionData     =   "RptImprEtiquetas.dsx":0000
End
Attribute VB_Name = "RptImprEtiquetas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ActiveReport_ReportStart()
   txtlis_importeC1.OutputFormat = "0." & ParCeros
   Field2.OutputFormat = "0." & ParCeros
End Sub

Private Sub Detail_Format()
   If Not Trim(txtlis_importeC1.Text) = "" Then
      If CDec(txtlis_importeC1.Text) = 0 Then
         txtlis_importeC1.Text = ""
         Label16.Caption = ""
      End If
   End If
   If Not Trim(Field2.Text) = "" Then
      If CDec(Field2.Text) = 0 Then
         Field2.Text = ""
         Label17.Caption = ""
      End If
   End If
End Sub
