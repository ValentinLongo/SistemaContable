VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptNEnvET2 
   Caption         =   "SIGC - RptNEnvET2 (ActiveReport)"
   ClientHeight    =   10665
   ClientLeft      =   75
   ClientTop       =   360
   ClientWidth     =   20250
   _ExtentX        =   35719
   _ExtentY        =   18812
   SectionData     =   "RptNEnvET2.dsx":0000
End
Attribute VB_Name = "RptNEnvET2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub PageHeader_BeforePrint()
   If Trim(ObsCli.Text) = "" Then
      ObsCli.Visible = False
   Else
      ObsCli.Visible = True
   End If
End Sub

