VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptListaFoto 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "SIGC - RptListaFoto (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   MaxButton       =   0   'False
   MinButton       =   0   'False
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptListaFoto.dsx":0000
End
Attribute VB_Name = "RptListaFoto"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_AfterPrint()
   Set Sub1 = Nothing
   Image1.Picture = Nothing
End Sub

Private Sub Detail_BeforePrint()
   On Error Resume Next
   Image1.Picture = LoadPicture(txtart_pathfoto.Text)

End Sub

Private Sub Detail_Format()
   SubRptListaFoto.DataControl1.ConnectionString = Cnn.ConnectionString
   SubRptListaFoto.DataControl1.Source = "Select * From Articulo Where art_pathfoto = '" & txtart_pathfoto.Text & "' Order By art_pathfoto, art_codtex, art_codnum"
   Config_Hoja SubRptListaFoto
   Set Sub1 = SubRptListaFoto
End Sub
