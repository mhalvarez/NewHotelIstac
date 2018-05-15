

Public Class Istac
    Private SQL As String
    Private DB As C_DATOS.C_DatosOledb
    Private DB2 As C_DATOS.C_DatosOledb

    Private mPrimerRegistro As Boolean = True
    Private mControlProvincia As String
    Private mAnadeResidencia As Boolean = False
    Private mControlResidencia As Integer


    Private hayerror As Boolean = False

    Private Mpernoctaciones As Integer
    Private MpernoctacionesAux As Integer

    Dim file As System.IO.StreamWriter
    Dim Result As String







    Private Sub ProcesarEspana()
        Try
            '       SQL = " /* Formatted on 26/10/2017 13:21:37 (QP5 v5.149.1003.31008) */ "
            SQL = "  SELECT EDTA_DATA, "
            SQL += "         NACI_CODI, "
            SQL += "         PROV_CODI, "
            SQL += "           PROV_DESC,PROV_COOF, "
            SQL += "         NVL(SUM (ENTR_NUAD) /2 ,0) ENTR_NUAD, "
            SQL += "         NVL(SUM (ENTR_NUCR) /2,0)  ENTR_NUCR, "
            SQL += "         NVL(SUM (ENTR_NUIN),0)  ENTR_NUIN, "
            SQL += "         NVL(SUM (ESTA_NUAD),0)  ESTA_NUAD, "
            SQL += "         NVL(SUM (ESTA_NUCR),0)  ESTA_NUCR, "
            SQL += "         NVL(SUM (ESTA_NUIN),0)  ESTA_NUIN, "
            SQL += "         NVL(SUM (CLIE_SALI),0)  CLIE_SALI, "
            SQL += "         NVL(SUM (CLIE_SALB),0)  CLIE_SALB, "
            SQL += "         NVL(SUM (ENTR_ALOJ),0)  ENTR_ALOJ, "
            SQL += "         NVL(SUM (ALOJ_SALI),0)  ALOJ_SALI, "
            SQL += "         NVL(SUM (ESTA_ALOJ),0)  ESTA_ALOJ, "
            SQL += "          "
            SQL += "          "
            SQL += "            NVL(SUM (ENTR_NUAD) /2 +  SUM (ENTR_NUCR) /2 ,0)    AS LLEGADAS, "
            SQL += "             NVL(SUM (CLIE_SALI),0)   AS SALIDAS, "
            SQL += "              NVL(SUM (ESTA_NUAD) +  SUM (ESTA_NUCR),0)   AS PERNOCTACIONES "
            SQL += "    FROM (  SELECT RESE_DAEN EDTA_DATA, "
            SQL += "                   NACI_CODI, "
            SQL += "                   PROV_CODI, "
            SQL += "                   PROV_DESC,PROV_COOF, "
            SQL += "                  SUM (RESE_NUAD) ENTR_NUAD, "
            SQL += "                    SUM (RESE_NUCR) ENTR_NUCR, "
            SQL += "                   SUM (RESE_NUIN) ENTR_NUIN, "
            SQL += "                   SUM (ESTA_NUAD) ESTA_NUAD, "
            SQL += "                   SUM (ESTA_NUCR) ESTA_NUCR, "
            SQL += "                   SUM (ESTA_NUIN) ESTA_NUIN, "
            SQL += "                   SUM (CLIE_SALI) CLIE_SALI, "
            SQL += "                   SUM (CLIE_SALB) CLIE_SALB, "
            SQL += "                   SUM (ALOJ_ENTR) ENTR_ALOJ, "
            SQL += "                   SUM (ALOJ_SALI) ALOJ_SALI, "
            SQL += "                   SUM (ESTA_ALOJ) ESTA_ALOJ "
            SQL += "              FROM (SELECT R.RESE_DAEN, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                         1 ALOJ_ENTR, "
            SQL += "                           R.RESE_NUAD, "
            SQL += "                           R.RESE_NUCR, "
            SQL += "                           R.RESE_NUIN, "
            SQL += "                           0 ALOJ_SALI, "
            SQL += "                           0 CLIE_SALI, "
            SQL += "                           0 CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DAEN >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DAEN <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                             AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                             AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI = '" & Me.TextBoxPais.Text & "'"
            SQL += "                             "
            SQL += "                    UNION ALL "
            SQL += "                    SELECT R.RESE_DASA, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                           0 ALOJ_ENTR, "
            SQL += "                           0 RESE_NUAD, "
            SQL += "                           0 RESE_NUCR, "
            SQL += "                           0 RESE_NUIN, "
            SQL += "                           1 ALOJ_SALI, "
            SQL += "                           R.RESE_NUAD + R.RESE_NUCR CLIE_SALI, "
            SQL += "                           R.RESE_NUIN CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DASA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DASA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                            AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                            AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI = '" & Me.TextBoxPais.Text & "'"
            SQL += "                    UNION ALL "
            SQL += "                    SELECT R.RESE_DAEN, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                           1 ALOJ_ENTR, "
            SQL += "                           R.RESE_NUAD, "
            SQL += "                           R.RESE_NUCR, "
            SQL += "                           R.RESE_NUIN, "
            SQL += "                           0 ALOJ_SALI, "
            SQL += "                           0 CLIE_SALI, "
            SQL += "                           0 CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DAEN >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DAEN <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                            AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                            AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI = '" & Me.TextBoxPais.Text & "'"
            SQL += "                    UNION ALL "
            SQL += "                      SELECT E.EDTA_DATA, "
            SQL += "                             R.NACI_CODI, "
            SQL += "                             NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                              PROV_DESC,PROV_COOF, "
            SQL += "                             0 ALOJ_ENTR, "
            SQL += "                             0 RESE_NUAD, "
            SQL += "                             0 RESE_NUCR, "
            SQL += "                             0 RESE_NUIN, "
            SQL += "                             0 ALOJ_SALI, "
            SQL += "                             0 CLIE_SALI, "
            SQL += "                             0 CLIE_SALB, "
            SQL += "                             SUM (R.RESE_NUAD) ESTA_NUAD, "
            SQL += "                             SUM (R.RESE_NUCR) ESTA_NUCR, "
            SQL += "                             SUM (R.RESE_NUIN) ESTA_NUIN, "
            SQL += "                             SUM (1) ESTA_ALOJ "
            SQL += "                        FROM TNHT_EDTD E, TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                       WHERE     E.EDTA_DATA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND E.EDTA_DATA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND R.RESE_DAEN <= E.EDTA_DATA "
            SQL += "                             AND R.RESE_DASA > E.EDTA_DATA "
            SQL += "                             AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                             AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                              AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                              AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                             AND R.NACI_CODI = '" & Me.TextBoxPais.Text & "'"
            SQL += "                    GROUP BY E.EDTA_DATA, R.NACI_CODI, NVL (C.PROV_CODI, '00')  ,PROV_DESC,PROV_COOF "
            SQL += "                    UNION ALL "
            SQL += "                      SELECT E.EDTA_DATA, "
            SQL += "                             R.NACI_CODI, "
            SQL += "                             NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                              PROV_DESC,PROV_COOF, "
            SQL += "                             0 ALOJ_ENTR, "
            SQL += "                             0 RESE_NUAD, "
            SQL += "                             0 RESE_NUCR, "
            SQL += "                             0 RESE_NUIN, "
            SQL += "                             0 ALOJ_SALI, "
            SQL += "                             0 CLIE_SALI, "
            SQL += "                             0 CLIE_SALB, "
            SQL += "                             SUM (O.OMPC_NUAD) ESTA_NUAD, "
            SQL += "                             SUM (O.OMPC_NUCR) ESTA_NUCR, "
            SQL += "                             SUM (O.OMPC_NUIN) ESTA_NUIN, "
            SQL += "                             0 ESTA_ALOJ "
            SQL += "                        FROM TNHT_EDTD E, "
            SQL += "                             TNHT_RESE R, "
            SQL += "                             TNHT_OMPC O, "
            SQL += "                             TNHT_CLIE C, TNHT_PROV P "
            SQL += "                       WHERE     E.EDTA_DATA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND E.EDTA_DATA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND R.RESE_DAEN <= E.EDTA_DATA "
            SQL += "                             AND R.RESE_DASA > E.EDTA_DATA "
            SQL += "                             AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                             AND R.RESE_CODI = O.RESE_CODI "
            SQL += "                             AND R.RESE_ANCI = O.RESE_ANCI "
            SQL += "                             AND O.OMPC_DAIN <= E.EDTA_DATA "
            SQL += "                             AND O.OMPC_DAFI > E.EDTA_DATA "
            SQL += "                             AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                              AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                              AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                             AND R.NACI_CODI =  '" & Me.TextBoxPais.Text & "'"
            SQL += "                    GROUP BY E.EDTA_DATA, R.NACI_CODI, NVL (C.PROV_CODI, '00') ,PROV_DESC,PROV_COOF  ) "
            SQL += "          GROUP BY RESE_DAEN, NACI_CODI, PROV_CODI  ,PROV_DESC,PROV_COOF) "
            SQL += "          WHERE NACI_CODI =  '" & Me.TextBoxPais.Text & "'"
            SQL += " GROUP BY EDTA_DATA, NACI_CODI, PROV_CODI ,PROV_DESC,PROV_COOF "
            SQL += " ORDER BY  NACI_CODI, PROV_CODI,EDTA_DATA "




            If IsNothing(DB) Then
                DB = New C_DATOS.C_DatosOledb(Me.TextBoxStrConexion.Text, True)
                DB2 = New C_DATOS.C_DatosOledb(Me.TextBoxStrConexion.Text, True)
            End If



            If DB.EstadoConexion <> ConnectionState.Open Then
                MsgBox("No Dispone de Acceso a la Base de Datos")
                Exit Sub
            End If


            DB.TraerLector(SQL)



            '20180515
            Me.mPrimerRegistro = True
            '

            While DB.mDbLector.Read
                If CDate(DB.mDbLector.Item("EDTA_DATA")).Month = Me.DateTimePickerHasta.Value.Month Then

                    If mPrimerRegistro Then
                        mPrimerRegistro = False
                        Me.mControlProvincia = DB.mDbLector.Item(3).ToString
                        Me.mAnadeResidencia = True
                        Me.mControlResidencia = 0

                    Else
                        Me.mControlResidencia = 1
                    End If

                    If Me.mControlProvincia <> DB.mDbLector.Item(3).ToString Then
                        Me.mControlProvincia = DB.mDbLector.Item(3).ToString
                        Me.mAnadeResidencia = True

                    End If


                    Me.GrabaXmlEspana(DB.mDbLector.Item(4).ToString.Trim, Format(DB.mDbLector.Item(0), "dd"), CInt(DB.mDbLector.Item("LLEGADAS")), CInt(DB.mDbLector.Item("SALIDAS")), CInt(DB.mDbLector.Item("PERNOCTACIONES")), mAnadeResidencia)
                    Me.ListBoxDebug.Items.Add(DB.mDbLector.Item(0).ToString.Trim & " " & DB.mDbLector.Item(1).ToString.Trim & " " & DB.mDbLector.Item(2).ToString.Trim & " " & DB.mDbLector.Item(3).ToString.PadRight(25, " ") & DB.mDbLector.Item(4).ToString.Trim & " " & DB.mDbLector.Item("LLEGADAS").ToString.PadLeft(3, " ") & " " & DB.mDbLector.Item("SALIDAS").ToString.PadLeft(3, " ") & " " & DB.mDbLector.Item("PERNOCTACIONES").ToString.PadLeft(3, " ") & " Repernoctaciones = " & Me.Mpernoctaciones)

                    If hayerror Then
                        Exit While
                    End If
                End If

            End While

            DB.mDbLector.Close()

            'XML
            '  writer.WriteEndElement()


            ' Fin de ultima resdiencia 
            Me.ListBoxDebug.Items.Add("cierra residencia")
            file.WriteLine("</RESIDENCIA>")




        Catch ex As Exception

            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub ProcesarOtros()
        Try
            '       SQL = " /* Formatted on 26/10/2017 13:21:37 (QP5 v5.149.1003.31008) */ "
            SQL = "  SELECT EDTA_DATA, "
            SQL += "         NACI_CODI, "
            SQL += "         PROV_CODI, "
            SQL += "           PROV_DESC,PROV_COOF, "
            SQL += "         NVL(SUM (ENTR_NUAD) /2 ,0) ENTR_NUAD, "
            SQL += "         NVL(SUM (ENTR_NUCR) /2,0)  ENTR_NUCR, "
            SQL += "         NVL(SUM (ENTR_NUIN),0)  ENTR_NUIN, "
            SQL += "         NVL(SUM (ESTA_NUAD),0)  ESTA_NUAD, "
            SQL += "         NVL(SUM (ESTA_NUCR),0)  ESTA_NUCR, "
            SQL += "         NVL(SUM (ESTA_NUIN),0)  ESTA_NUIN, "
            SQL += "         NVL(SUM (CLIE_SALI),0)  CLIE_SALI, "
            SQL += "         NVL(SUM (CLIE_SALB),0)  CLIE_SALB, "
            SQL += "         NVL(SUM (ENTR_ALOJ),0)  ENTR_ALOJ, "
            SQL += "         NVL(SUM (ALOJ_SALI),0)  ALOJ_SALI, "
            SQL += "         NVL(SUM (ESTA_ALOJ),0)  ESTA_ALOJ, "
            SQL += "          "
            SQL += "          "
            SQL += "            NVL(SUM (ENTR_NUAD) /2 +  SUM (ENTR_NUCR) /2,0)    AS LLEGADAS, "
            SQL += "             NVL(SUM (CLIE_SALI),0)   AS SALIDAS, "
            SQL += "              NVL(SUM (ESTA_NUAD) +  SUM (ESTA_NUCR),0)   AS PERNOCTACIONES "
            SQL += "    FROM (  SELECT RESE_DAEN EDTA_DATA, "
            SQL += "                   NACI_CODI, "
            SQL += "                   PROV_CODI, "
            SQL += "                   PROV_DESC,PROV_COOF, "
            SQL += "                  SUM (RESE_NUAD) ENTR_NUAD, "
            SQL += "                    SUM (RESE_NUCR) ENTR_NUCR, "
            SQL += "                   SUM (RESE_NUIN) ENTR_NUIN, "
            SQL += "                   SUM (ESTA_NUAD) ESTA_NUAD, "
            SQL += "                   SUM (ESTA_NUCR) ESTA_NUCR, "
            SQL += "                   SUM (ESTA_NUIN) ESTA_NUIN, "
            SQL += "                   SUM (CLIE_SALI) CLIE_SALI, "
            SQL += "                   SUM (CLIE_SALB) CLIE_SALB, "
            SQL += "                   SUM (ALOJ_ENTR) ENTR_ALOJ, "
            SQL += "                   SUM (ALOJ_SALI) ALOJ_SALI, "
            SQL += "                   SUM (ESTA_ALOJ) ESTA_ALOJ "
            SQL += "              FROM (SELECT R.RESE_DAEN, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                         1 ALOJ_ENTR, "
            SQL += "                           R.RESE_NUAD, "
            SQL += "                           R.RESE_NUCR, "
            SQL += "                           R.RESE_NUIN, "
            SQL += "                           0 ALOJ_SALI, "
            SQL += "                           0 CLIE_SALI, "
            SQL += "                           0 CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DAEN >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DAEN <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                             AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                             AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI <> '" & Me.TextBoxPais.Text & "'"
            SQL += "                             "
            SQL += "                    UNION ALL "
            SQL += "                    SELECT R.RESE_DASA, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                           0 ALOJ_ENTR, "
            SQL += "                           0 RESE_NUAD, "
            SQL += "                           0 RESE_NUCR, "
            SQL += "                           0 RESE_NUIN, "
            SQL += "                           1 ALOJ_SALI, "
            SQL += "                           R.RESE_NUAD + R.RESE_NUCR CLIE_SALI, "
            SQL += "                           R.RESE_NUIN CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DASA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DASA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                            AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                            AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI <> '" & Me.TextBoxPais.Text & "'"
            SQL += "                    UNION ALL "
            SQL += "                    SELECT R.RESE_DAEN, "
            SQL += "                           R.NACI_CODI, "
            SQL += "                           NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                            PROV_DESC,PROV_COOF, "
            SQL += "                           1 ALOJ_ENTR, "
            SQL += "                           R.RESE_NUAD, "
            SQL += "                           R.RESE_NUCR, "
            SQL += "                           R.RESE_NUIN, "
            SQL += "                           0 ALOJ_SALI, "
            SQL += "                           0 CLIE_SALI, "
            SQL += "                           0 CLIE_SALB, "
            SQL += "                           0 ESTA_NUAD, "
            SQL += "                           0 ESTA_NUCR, "
            SQL += "                           0 ESTA_NUIN, "
            SQL += "                           0 ESTA_ALOJ "
            SQL += "                      FROM TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                     WHERE     R.RESE_DAEN >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_DAEN <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                           AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                           AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                            AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                            AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                           AND R.NACI_CODI <> '" & Me.TextBoxPais.Text & "'"
            SQL += "                    UNION ALL "
            SQL += "                      SELECT E.EDTA_DATA, "
            SQL += "                             R.NACI_CODI, "
            SQL += "                             NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                              PROV_DESC,PROV_COOF, "
            SQL += "                             0 ALOJ_ENTR, "
            SQL += "                             0 RESE_NUAD, "
            SQL += "                             0 RESE_NUCR, "
            SQL += "                             0 RESE_NUIN, "
            SQL += "                             0 ALOJ_SALI, "
            SQL += "                             0 CLIE_SALI, "
            SQL += "                             0 CLIE_SALB, "
            SQL += "                             SUM (R.RESE_NUAD) ESTA_NUAD, "
            SQL += "                             SUM (R.RESE_NUCR) ESTA_NUCR, "
            SQL += "                             SUM (R.RESE_NUIN) ESTA_NUIN, "
            SQL += "                             SUM (1) ESTA_ALOJ "
            SQL += "                        FROM TNHT_EDTD E, TNHT_RESE R, TNHT_CLIE C, TNHT_PROV P "
            SQL += "                       WHERE     E.EDTA_DATA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND E.EDTA_DATA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND R.RESE_DAEN <= E.EDTA_DATA "
            SQL += "                             AND R.RESE_DASA > E.EDTA_DATA "
            SQL += "                             AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                             AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                              AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                              AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                             AND R.NACI_CODI <> '" & Me.TextBoxPais.Text & "'"
            SQL += "                    GROUP BY E.EDTA_DATA, R.NACI_CODI, NVL (C.PROV_CODI, '00')  ,PROV_DESC,PROV_COOF "
            SQL += "                    UNION ALL "
            SQL += "                      SELECT E.EDTA_DATA, "
            SQL += "                             R.NACI_CODI, "
            SQL += "                             NVL (C.PROV_CODI, '00') PROV_CODI, "
            SQL += "                              PROV_DESC,PROV_COOF, "
            SQL += "                             0 ALOJ_ENTR, "
            SQL += "                             0 RESE_NUAD, "
            SQL += "                             0 RESE_NUCR, "
            SQL += "                             0 RESE_NUIN, "
            SQL += "                             0 ALOJ_SALI, "
            SQL += "                             0 CLIE_SALI, "
            SQL += "                             0 CLIE_SALB, "
            SQL += "                             SUM (O.OMPC_NUAD) ESTA_NUAD, "
            SQL += "                             SUM (O.OMPC_NUCR) ESTA_NUCR, "
            SQL += "                             SUM (O.OMPC_NUIN) ESTA_NUIN, "
            SQL += "                             0 ESTA_ALOJ "
            SQL += "                        FROM TNHT_EDTD E, "
            SQL += "                             TNHT_RESE R, "
            SQL += "                             TNHT_OMPC O, "
            SQL += "                             TNHT_CLIE C, TNHT_PROV P "
            SQL += "                       WHERE     E.EDTA_DATA >=  '" & Format(Me.DateTimePickerDesde.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND E.EDTA_DATA <=  '" & Format(Me.DateTimePickerHasta.Value, "dd/MM/yyyy") & "'"
            SQL += "                             AND R.RESE_DAEN <= E.EDTA_DATA "
            SQL += "                             AND R.RESE_DASA > E.EDTA_DATA "
            SQL += "                             AND R.RESE_ESTA IN ('2', '5') "
            SQL += "                             AND R.RESE_CODI = O.RESE_CODI "
            SQL += "                             AND R.RESE_ANCI = O.RESE_ANCI "
            SQL += "                             AND O.OMPC_DAIN <= E.EDTA_DATA "
            SQL += "                             AND O.OMPC_DAFI > E.EDTA_DATA "
            SQL += "                             AND R.CLIE_CODI = C.CLIE_CODI(+) "
            SQL += "                              AND C.NACI_CODI = P.NACI_CODI "
            SQL += "                              AND C.PROV_CODI = P.PROV_CODI "
            SQL += "                             AND R.NACI_CODI <>  '" & Me.TextBoxPais.Text & "'"
            SQL += "                    GROUP BY E.EDTA_DATA, R.NACI_CODI, NVL (C.PROV_CODI, '00') ,PROV_DESC,PROV_COOF  ) "
            SQL += "          GROUP BY RESE_DAEN, NACI_CODI, PROV_CODI  ,PROV_DESC,PROV_COOF) "
            SQL += "          WHERE NACI_CODI <>  '" & Me.TextBoxPais.Text & "'"
            SQL += " GROUP BY EDTA_DATA, NACI_CODI, PROV_CODI ,PROV_DESC,PROV_COOF "
            SQL += " ORDER BY  NACI_CODI, PROV_CODI,EDTA_DATA "




            If IsNothing(DB) Then
                DB = New C_DATOS.C_DatosOledb(Me.TextBoxStrConexion.Text, True)
                DB2 = New C_DATOS.C_DatosOledb(Me.TextBoxStrConexion.Text, True)
            End If



            If DB.EstadoConexion <> ConnectionState.Open Then
                MsgBox("No Dispone de Acceso a la Base de Datos")
                Exit Sub
            End If


            DB.TraerLector(SQL)

            '20180515
            Me.mPrimerRegistro = True
            '


            While DB.mDbLector.Read

                If CDate(DB.mDbLector.Item("EDTA_DATA")).Month = Me.DateTimePickerHasta.Value.Month Then



                    If mPrimerRegistro Then
                        mPrimerRegistro = False
                        Me.mControlProvincia = DB.mDbLector.Item("NACI_CODI")
                        Me.mAnadeResidencia = True
                        Me.mControlResidencia = 0

                    Else
                        Me.mControlResidencia = 1
                    End If

                    If Me.mControlProvincia <> DB.mDbLector.Item("NACI_CODI") Then
                        Me.mControlProvincia = DB.mDbLector.Item("NACI_CODI")
                        Me.mAnadeResidencia = True

                    End If


                    Me.GrabaXmlOtros(DB.mDbLector.Item("NACI_CODI").ToString.Trim, Format(DB.mDbLector.Item(0), "dd"), CInt(DB.mDbLector.Item("LLEGADAS")), CInt(DB.mDbLector.Item("SALIDAS")), CInt(DB.mDbLector.Item("PERNOCTACIONES")), mAnadeResidencia)
                    Me.ListBoxDebug.Items.Add(DB.mDbLector.Item(0).ToString.Trim & " " & DB.mDbLector.Item(1).ToString.Trim & " " & DB.mDbLector.Item(2).ToString.Trim & " " & DB.mDbLector.Item(3).ToString.PadRight(25, " ") & DB.mDbLector.Item(4).ToString.Trim & " " & DB.mDbLector.Item("LLEGADAS").ToString.PadLeft(3, " ") & " " & DB.mDbLector.Item("SALIDAS").ToString.PadLeft(3, " ") & " " & DB.mDbLector.Item("PERNOCTACIONES").ToString.PadLeft(3, " ") & " Repernoctaciones = " & Me.Mpernoctaciones)

                    If hayerror Then
                        Exit While
                    End If
                End If

            End While

            DB.mDbLector.Close()

            'XML
            '  writer.WriteEndElement()

            '20180515
            Me.ListBoxDebug.Items.Add("cierra residencia")
            file.WriteLine("</RESIDENCIA>")
            '
            Me.ListBoxDebug.Items.Add("close document")
            ' Fin de ultima resdiencia 



        Catch ex As Exception

            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub ButtonProcesar_Click(sender As Object, e As EventArgs) Handles ButtonProcesar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.ListBoxDebug.Items.Clear()
            Me.ListBoxDebug.Update()

            'file
            file = My.Computer.FileSystem.OpenTextFileWriter("c:\TEMPORAL\test.XML", False)
            Me.ProcesarOtros()
            Me.ProcesarEspana()

            MsgBox("File in c:\temporal\test.xml")
            file.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Istac_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If IsNothing(DB) = False Then
                DB.CerrarConexion()
            End If
            If IsNothing(DB2) = False Then
                DB2.CerrarConexion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GrabaXmlEspana(vProvincia As String, vDia As String, vEntradas As String, vSalidas As String, vPernoctaciones As String, vAnaderesidencia As Boolean)
        Try

            ' no es la primerta residencia se cierra la ultima 
            If vAnaderesidencia And mControlResidencia = 1 Then
                Me.ListBoxDebug.Items.Add("cierra residencia")

                file.WriteLine("</RESIDENCIA>")
            End If


            If vAnaderesidencia Then
                Me.ListBoxDebug.Items.Add("abre residencia")

                file.WriteLine("<RESIDENCIA>")
                file.WriteLine("<ID_PROVINCIA_ISLA>" & vProvincia & "</ID_PROVINCIA_ISLA>")

                Me.Mpernoctaciones = vPernoctaciones

            End If





            file.WriteLine("<MOVIMIENTO>")
            file.WriteLine("<N_DIA>" & vDia & "</N_DIA>")
            file.WriteLine("<ENTRADAS>" & vEntradas & "</ENTRADAS>")
            file.WriteLine("<SALIDAS>" & vSalidas & "</SALIDAS>")
            ' file.WriteLine("<PERNOCTACIONES>" & vPernoctaciones & "</PERNOCTACIONES>")

            If vAnaderesidencia Then
                Me.MpernoctacionesAux = Me.Mpernoctaciones + vEntradas - vSalidas
                file.WriteLine("<PERNOCTACIONES>" & Me.Mpernoctaciones & "</PERNOCTACIONES>")
            Else
                Me.Mpernoctaciones = Me.Mpernoctaciones + vEntradas - vSalidas
                file.WriteLine("<PERNOCTACIONES>" & Me.Mpernoctaciones & "</PERNOCTACIONES>")
            End If

            file.WriteLine("</MOVIMIENTO>")






            Me.mAnadeResidencia = False


        Catch ex As Exception
            hayerror = True
            MsgBox(ex.Message)
            'XML

        End Try
    End Sub
    Private Sub GrabaXmlOtros(vpais As String, vDia As String, vEntradas As String, vSalidas As String, vPernoctaciones As String, vAnaderesidencia As Boolean)
        Try

            ' no es la primerta residencia se cierra la ultima 
            If vAnaderesidencia And mControlResidencia = 1 Then
                Me.ListBoxDebug.Items.Add("cierra residencia")

                file.WriteLine("</RESIDENCIA>")
            End If


            If vAnaderesidencia Then
                Me.ListBoxDebug.Items.Add("abre residencia")

                file.WriteLine("<RESIDENCIA>")
                file.WriteLine("<ID_PAIS>" & BuscaCiso(vpais) & "</ID_PAIS>")

                Me.Mpernoctaciones = vPernoctaciones

            End If





            file.WriteLine("<MOVIMIENTO>")
            file.WriteLine("<N_DIA>" & vDia & "</N_DIA>")
            file.WriteLine("<ENTRADAS>" & vEntradas & "</ENTRADAS>")
            file.WriteLine("<SALIDAS>" & vSalidas & "</SALIDAS>")
            ' file.WriteLine("<PERNOCTACIONES>" & vPernoctaciones & "</PERNOCTACIONES>")

            If vAnaderesidencia Then
                Me.MpernoctacionesAux = Me.Mpernoctaciones + vEntradas - vSalidas
                file.WriteLine("<PERNOCTACIONES>" & Me.Mpernoctaciones & "</PERNOCTACIONES>")
            Else
                Me.Mpernoctaciones = Me.Mpernoctaciones + vEntradas - vSalidas
                file.WriteLine("<PERNOCTACIONES>" & Me.Mpernoctaciones & "</PERNOCTACIONES>")
            End If

            file.WriteLine("</MOVIMIENTO>")






            Me.mAnadeResidencia = False


        Catch ex As Exception
            hayerror = True
            MsgBox(ex.Message)
            'XML

        End Try
    End Sub

    Private Function BuscaCiso(vPais As String) As String
        Try
            Dim SQL3 As String



            SQL3 = "SELECT NVL(NACI_CISO,'?') AS NACI_CISO FROM TNHT_NACI WHERE NACI_CODI = '" & vPais & "'"

            Result = Me.DB2.EjecutaSqlScalar(SQL3)

            Return Result
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "?"
        End Try

    End Function

    Private Sub Istac_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try


            '   Dim s As String = "201208"
            Dim s As String
            If Now.Month > 1 Then
                s = Now.Year & (Now.Month - 1).ToString.PadLeft(2, "0")
            Else
                s = Now.Year - 1 & "12"
            End If

            Dim firstDay = Date.ParseExact(s, "yyyyMM", Nothing)
            Dim lastDay = firstDay.AddMonths(1).AddDays(-1)
            Dim year = firstDay.Year

            Me.DateTimePickerDesde.Value = CDate(Format(firstDay, "dd/MM/yyyy"))
            Me.DateTimePickerHasta.Value = CDate(Format(lastDay, "dd/MM/yyyy"))
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.DateTimePickerDesde.Value = Now
            Me.DateTimePickerHasta.Value = Now
        End Try
    End Sub
End Class
