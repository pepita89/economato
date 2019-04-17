Module General
    'Public esNuevo As Boolean
    'Public oplato As NegEconomato.Plato
    'Public oMenu As NegEconomato.ProgramacionMenu
    'Public oComprobante As NegEconomato.Comprobante
    'Public oMovimiento As NegEconomato.Movimientos
    'Public oMovimientoAuxiliar As NegEconomato.Movimientos
    'Public oSobrante As NegEconomato.Sobrantes
    'Public OCtrolInv As NegEconomato.ControlInventario
    'Public oValeRetiro As NegEconomato.ValeRetiro
    Public Const EGRESO_DOSIFMENU = 5
    Public Const EGRESO_OTRADOSIF = 6
    Public Const EGRESO_PLANILLASEM = 7
    Public Const EGRESO_PEDIDOCOCINA = 8
    Public Const EGRESO_MERCDIARIA = 9

    Public Const DEV_DOSIFMENU = 20
    Public Const DEV_OTRADOSIF = 21
    Public Const DEV_PLANILLASEM = 22
    Public Const DEV_PEDIDOCOCINA = 23
    Public Const DEV_MERCDIARIA = 24

    Public Const MERMA = 10
    Public Const INVENTARIO = 11

    Public Const REMITO = 1
    Public Const REMITO_PROV = 18
    Public Const FACTURA = 3
    Public Const FACTURA_PROV = 25

    Public Const ENCARGA = 1
    Public Const DEFINITIVA = 2
    Public Const PROVISORIA = 3

    Public Const ALTA = 0
    Public Const BAJA = -1

    Public Const FRACC = 0
    Public Const NOFRACC = -1

    'Public Const COMPLETA = 2
    'Public Const SINAPROB = 3

    Public ArrEle As Array
    Public oColAux As Collection
    Public oMenu As NegEconomato.ProgramacionMenu
    Public oPlanillasConfig As NegEconomato.PlanillaSemanalConfiguracion
    Public oPlanilla As New NegEconomato.PlanillaSemanal
    Public cdValeSelect As Short
    Public cdMovTraido As Integer


    Public Sub CargarCboProveedores(ByRef cboProveedores As DropDownList, Optional ByVal blTodos As Boolean = False)
        Dim oProv As New NegEconomato.Proveedor
        Dim dt As DataTable = oProv.ListarProveedoresAll(ALTA)
        Dim dr As DataRow = dt.NewRow
        dr(1) = 0
        dr(2) = "Todos"
        If blTodos Then
            dt.Rows.InsertAt(dr, 0)
        End If
        cboProveedores.DataSource = dt
        cboProveedores.DataValueField = "cdProveedor"
        cboProveedores.DataTextField = "dsRazonSocial"
        cboProveedores.DataBind()
        oProv = Nothing

    End Sub
    Public Sub CargarCboElementosbySector(ByVal cboElementos As DropDownList, ByVal pcdSector As Integer)
        Try
            Dim _oPlanilla As New NegEconomato.PlanillaSemanal
            cboElementos.DataSource = _oPlanilla.TraerSubCategoriaByConfigPlanillas(pcdSector)
            cboElementos.DataValueField = "cdElemento"
            cboElementos.DataTextField = "dsElemento"
            cboElementos.DataBind()
            _oPlanilla = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboEgresos(ByRef cboEgresos As DropDownList)
        Try
            Dim oVale As New NegEconomato.ValeRetiro
            cboEgresos.DataSource = oVale.SelectValeRetiroTodos
            cboEgresos.DataValueField = "cdMovimiento"
            cboEgresos.DataTextField = "cdVale"
            cboEgresos.DataBind()
            oVale = Nothing

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboProveedoresU(ByRef cboProveedores As DropDownList)
        Try
            Dim oProv As New NegEconomato.Proveedor
            Dim dt As DataTable
            Dim i As Integer
            dt = oProv.ListarProveedoresAll(ALTA)

            For i = 0 To dt.Rows.Count - 1
                cboProveedores.Items.Add(New ListItem(dt.Rows(i).Item(2), dt.Rows(i).Item(1)))
            Next

            cboProveedores.DataBind()
            oProv = Nothing

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub _CargarOrdenesProvision(ByVal cboOrden As DropDownList, ByVal cdProveedores As Integer, ByVal _desde As String, ByVal _hasta As String)
        Try
            Dim oProv As New NegEconomato.OrdenProvision
            Dim dt As DataTable
            Dim i As Integer

            cboOrden.Items.Clear()
            dt = oProv.ListarOrdenesProvisionByRango(cdProveedores, _desde, _hasta)
            cboOrden.Items.Add(New ListItem("(Todas)", 0))
            For i = 0 To dt.Rows.Count - 1
                cboOrden.Items.Add(New ListItem(dt.Rows(i).Item(4), dt.Rows(i).Item(0)))
            Next

            cboOrden.DataBind()
            oProv = Nothing

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub CargarCboSectoresbyBol(ByRef cboSectores As DropDownList, ByVal blCocina As Boolean, ByVal blConsumidor As Boolean, ByVal blPlanillaSem As Boolean, ByVal blDeposito As Boolean, Optional ByVal Todos As Boolean = False)
        Dim dtt As DataTable
        Dim dbGen As New NegEconomato.General
        Try
            Dim cdcocina, cdConsumidor, cdPlanilla, cdDeposito As Integer
            cdcocina = IIf(blCocina = True, "0", "-1")
            cdConsumidor = IIf(blConsumidor = True, "0", "-1")
            cdPlanilla = IIf(blPlanillaSem = True, "0", "-1")
            cdDeposito = IIf(blDeposito = True, "0", "-1")
            dtt = dbGen.SelectSectores(cdcocina, cdConsumidor, cdPlanilla, cdDeposito).Tables(0)
            Dim dr As DataRow = dtt.NewRow
            dr(1) = 0
            dr(2) = "Todos"
            If Todos Then
                dtt.Rows.InsertAt(dr, 0)
            End If
            cboSectores.DataSource = dtt
            cboSectores.DataValueField = "cdSector"
            cboSectores.DataTextField = "dsSector"
            cboSectores.DataBind()
            dbGen = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Function TraercdSectorDeposito() As Integer
        Dim oGen As New NegEconomato.General
        Try
            Return oGen.TraercdSectorDeposito()
        Catch ex As Exception

        Finally
            oGen = Nothing
        End Try
    End Function
    Public Sub CargarCboPersonasBySector(ByRef cboPersonasSectores As DropDownList, ByVal cdSector As Integer, ByVal blFirmante As Boolean, ByVal blConsumidor As Boolean)
        Dim ds As DataSet
        Dim dbGen As New NegEconomato.General
        Try
            Dim cdFirmante, cdConsumidor As Integer
            cdFirmante = IIf(blFirmante = True, "0", "-1")
            cdConsumidor = IIf(blConsumidor = True, "0", "-1")


            ds = dbGen.SelectSectoresPersonasBySector(cdSector, cdFirmante, cdConsumidor)
            cboPersonasSectores.DataSource = ds
            cboPersonasSectores.DataValueField = "cdPersona"
            cboPersonasSectores.DataTextField = "dsPersona"
            cboPersonasSectores.DataBind()
            dbGen = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboPlatos(ByRef cboTipoPlato As DropDownList, ByVal cboPlato As DropDownList, Optional ByVal otroPlato As Boolean = False)
        Dim dt As DataTable
        Dim dbDatos As New NegEconomato.Plato
        Dim dr As DataRow
        Try
            dt = dbDatos.ObtenerPlatosByTipo(cboTipoPlato.SelectedValue)
            If otroPlato Then
                dr = dt.NewRow
                dr.Item("cdPlato") = 0
                dr.Item("dsPlato") = "Otro Plato..."
                dt.Rows.InsertAt(dr, 0)
            End If
            cboPlato.DataSource = dt
            cboPlato.DataValueField = "cdPlato"
            cboPlato.DataTextField = "dsPlato"
            cboPlato.DataBind()
            dbDatos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboResponsables(ByRef cboResponsables As DropDownList, Optional ByVal pcdSector As Integer = 0)
        Try
            Dim oMov As New NegEconomato.Movimientos
            cboResponsables.DataSource = oMov.SelectResponsables(pcdSector)
            cboResponsables.DataValueField = "cdPersona"
            cboResponsables.DataTextField = "dsPersona"
            cboResponsables.DataBind()
            oMov = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboResponsablesDeposito(ByRef cboResponsables As DropDownList)
        Try
            Dim oMov As New NegEconomato.Movimientos
            cboResponsables.DataSource = oMov.SelectResponsablesDeposito
            cboResponsables.DataValueField = "cdPersona"
            cboResponsables.DataTextField = "dsPersona"
            cboResponsables.DataBind()
            oMov = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboSectoresCocina(ByVal cboSectores As DropDownList)
        Try
            Dim oSobrantes As New NegEconomato.Sobrantes
            cboSectores.DataSource = oSobrantes.TraerSectoresCocina
            cboSectores.DataValueField = "cdSector"
            cboSectores.DataTextField = "dsSector"
            cboSectores.DataBind()
            oSobrantes = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboDependencia(ByVal cboDependencias As DropDownList, Optional ByVal Todos As Boolean = False)
        Try
            Dim oGral As New NegEconomato.General
            Dim dtt As DataTable = oGral.SelectDependenciasAll
            Dim dr As DataRow = dtt.NewRow
            dr(0) = -1
            dr(1) = "Todos"
            If Todos Then
                dtt.Rows.InsertAt(dr, 0)
            End If
            cboDependencias.DataSource = dtt
            cboDependencias.DataValueField = "cdPadre"
            cboDependencias.DataTextField = "dsNombreUnidad"
            cboDependencias.DataBind()
            oGral = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboSectores(ByVal cboSectores As DropDownList, Optional ByVal Todos As Boolean = False, Optional ByVal cdPadre As Integer = -1)
        Try
            Dim oGral As New NegEconomato.General
            Dim dtt As DataTable = oGral.SelectSectoresAll(cdPadre)
            Dim dr As DataRow = dtt.NewRow
            dr(0) = 0
            dr(1) = "Todos"
            If Todos Then
                dtt.Rows.InsertAt(dr, 0)
            End If
            cboSectores.DataSource = dtt
            cboSectores.DataValueField = "cdSector"
            cboSectores.DataTextField = "dsSector"
            cboSectores.DataBind()
            oGral = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub CargarCboTiposMovimientos(ByRef cboMovimientos As DropDownList, ByVal pdsTipo As String, Optional ByVal Todos As Boolean = False, Optional ByVal pdsClasificacion As String = "")
        Try
            Dim oGral As New NegEconomato.General
            Dim dtt As DataTable = oGral.SelectTiposMovimientos(pdsTipo, pdsClasificacion)
            Dim dr As DataRow = dtt.NewRow
            dr(1) = 0
            dr(2) = "Todos"
            If Todos Then
                dtt.Rows.InsertAt(dr, 0)
            End If
            cboMovimientos.DataSource = dtt
            cboMovimientos.DataValueField = "cdTipoMovimiento"
            cboMovimientos.DataTextField = "dsDescripcion"
            cboMovimientos.DataBind()
            oGral = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Private Sub CargarSectoresSolicitante(ByVal TipoMovimiento As Integer)
        Dim oParam() As SqlClient.SqlParameter = {New SqlClient.SqlParameter("@cdTipoMovimeinto", TipoMovimiento)}

        Dim ds As DataSet

    End Sub

    Public Sub CargarEntrada(ByRef cboEntrada As DropDownList)
        Try
            Dim oPlato As New NegEconomato.Plato
            Dim ds As DataTable

            ds = oPlato.ObtenerPlatosByTipo(1)
            If ds.Rows.Count > 0 Then
                cboEntrada.DataSource = ds
                cboEntrada.DataValueField = "cdPlato"
                cboEntrada.DataTextField = "dsPlato"
                cboEntrada.DataBind()
            End If
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarTiposDosificacion(ByVal cboTipo As DropDownList)
        Dim oDos As New NegEconomato.Dosificacion
        Dim ds As DataSet

        ds = oDos.TraerTiposDosificaciones()
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                cboTipo.DataSource = ds
                cboTipo.DataValueField = "cdCodigo"
                cboTipo.DataTextField = "dsDetalle"
                cboTipo.DataBind()
            End If
        End If

        oDos = Nothing
    End Sub
    Public Sub CargarPostre(ByRef cboPostre As DropDownList)
        Try
            Dim oPlato As New NegEconomato.Plato
            Dim ds As DataTable

            ds = oPlato.ObtenerPlatosByTipo(3)
            If ds.Rows.Count > 0 Then
                cboPostre.DataSource = ds
                cboPostre.DataValueField = "cdPlato"
                cboPostre.DataTextField = "dsPlato"
                cboPostre.DataBind()
            End If
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarPlato(ByRef cboPostre As DropDownList)
        Try
            Dim oPlato As New NegEconomato.Plato
            Dim ds As DataTable

            ds = oPlato.ObtenerPlatosByTipo(2)
            If ds.Rows.Count > 0 Then
                cboPostre.DataSource = ds
                cboPostre.DataValueField = "cdPlato"
                cboPostre.DataTextField = "dsPlato"
                cboPostre.DataBind()
            End If
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Function ConvertirAnsi(ByVal Fecha As Date) As String
        Try
            '30/08/05 ==> 20050830 
            Dim Memoria As String
            Memoria = Fecha.Year()

            If Fecha.Month < 10 Then
                Memoria = Memoria & "0" & Fecha.Month
            Else
                Memoria = Memoria & Fecha.Month
            End If

            If Fecha.Day < 10 Then
                Memoria = Memoria & "0" & Fecha.Day
            Else
                Memoria = Memoria & Fecha.Day
            End If

            Return Memoria
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Function
    Public Function ConvertirTresDecimales(ByVal dblValor As Decimal) As Decimal
        dblValor = Replace(dblValor, ".", ",")

        If ((CStr(dblValor).IndexOf(",") + 1) - CStr(dblValor).Length) < 0 Then
            '//Hay decimales tras la coma
            If (CStr(dblValor).IndexOf(",")) <> -1 Then
                Select Case CStr(dblValor).Substring((CStr(dblValor).IndexOf(",") + 1), ((CStr(dblValor).Length) - (CStr(dblValor).IndexOf(",") + 1))).Length
                    Case 1
                        Return CType(CStr(dblValor).Substring(0, (CStr(dblValor).IndexOf(",") + 2)), Decimal)
                    Case 2
                        Return CType(CStr(dblValor).Substring(0, (CStr(dblValor).IndexOf(",") + 3)), Decimal)
                    Case Is >= 3
                        Return CType(CStr(dblValor).Substring(0, (CStr(dblValor).IndexOf(",") + 4)), Decimal)
                End Select
            Else : Return dblValor
            End If
        End If
    End Function
    Public Sub CargarCboEstadosOP(ByRef cboEstados As DropDownList, Optional ByVal SelectedValue As Integer = 1)
        Try
            Dim oOrdProv As New NegEconomato.OrdenProvision
            cboEstados.DataSource = oOrdProv.ListarEstadosOP
            cboEstados.DataValueField = "cdCodigo"
            cboEstados.DataTextField = "dsDetalle"
            cboEstados.SelectedValue = SelectedValue
            cboEstados.DataBind()
            oOrdProv = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboRubros(ByRef cboRubro As DropDownList)
        Try
            Dim dbDatos As New NegEconomato.Categorizacion
            cboRubro.DataSource = dbDatos.ListarCategorizacionesAll("0")
            cboRubro.DataBind()
            dbDatos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    'Public oEgreso As NegEconomato.Egreso
    Public Sub SetearFoco(ByVal pagina As System.Web.UI.Page, ByVal ctrl As Control)
        Try
            Dim strScript As String
            Dim clientID As String = ctrl.ClientID
            Dim script As New System.Text.StringBuilder
            script.Append("<script language='javascript'>")
            script.Append("document.getElementById('" & clientID & "').scrollIntoView();")
            script.Append("document.getElementById('" & clientID & "').focus();")
            script.Append("</script>")
            pagina.RegisterStartupScript("setScrollAndFocus", script.ToString())
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboUnidades(ByRef cbounidades As DropDownList)
        Try
            Dim dbDatos As New NegEconomato.Unidades
            cbounidades.DataSource = dbDatos.SelectUnidadesAll
            cbounidades.DataBind()
            dbDatos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboPresentaciones(ByRef cbopresentaciones As DropDownList)
        Try
            Dim dbDatos As New NegEconomato.Presentaciones
            cbopresentaciones.DataSource = dbDatos.SelectPresentacionesAll
            cbopresentaciones.DataBind()
            dbDatos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarOrdenesProvision(ByRef cboCombo As DropDownList, ByVal cdProveedor As Integer, Optional ByVal mostrarALL As Boolean = False)
        'If mostrarALL = False Then
        '    Dim oOrdenProvision As New NegEconomato.OrdenProvision
        '    Dim ex As New DataTable
        '    ex = oOrdenProvision.ListarOrdenProvisionByProveedor(cdProveedor)

        '    cboCombo.DataSource = ex
        '    cboCombo.DataValueField = "cdOrden"
        '    cboCombo.DataTextField = "dsOrdenProv"
        '    cboCombo.DataBind()
        'Else
        Dim oOrdenProvision As New NegEconomato.OrdenProvision
        Dim ex As New DataTable
        ex = oOrdenProvision.ListarOrdenProvisionByProveedor(cdProveedor, mostrarALL)

        cboCombo.DataSource = ex
        cboCombo.DataValueField = "cdOrden"
        cboCombo.DataTextField = "dsOrdenProv"
        cboCombo.DataBind()
        'End If
    End Sub

    Public Sub CargarOrdenesProvisionVigentesXProveedorEstado(ByRef cboCombo As DropDownList, ByVal pcdProveedor As Integer, ByVal pcdEstado As Integer)
        Dim oOrdenProvision As New NegEconomato.OrdenProvision
        cboCombo.DataSource = oOrdenProvision.ListarOrdenProvisionVigentesXProveedorEstado(pcdProveedor, pcdEstado)
        cboCombo.DataValueField = "cdOrden"
        cboCombo.DataTextField = "dsOrdenProv"
        cboCombo.DataBind()
    End Sub

    Public Sub CargarElementos(ByRef cboElementos As DropDownList, ByVal cboingredientes As DropDownList)
        Try
            Dim dbDatos As New NegEconomato.Elemento
            Dim dts As DataTable = dbDatos.SelectElementosBySubCategorias(cboingredientes.SelectedValue)

            'Agrego un Item más
            Dim sarasa As DataRow = dts.NewRow
            sarasa("cdElemento") = 0
            sarasa("dsNombre") = "INDISTINTO"
            dts.Rows.InsertAt(sarasa, 0)

            cboElementos.DataSource = dts
            cboElementos.DataValueField = "cdElemento"
            cboElementos.DataTextField = "dsNombre"
            cboElementos.DataBind()
            dbDatos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarRubros(ByRef cboRubro As DropDownList)
        Try
            Dim dbDatos As New NegEconomato.Categorizacion
            Dim dts As DataTable = dbDatos.ListarCategorizacionesAll("0")
            If dts.Rows.Count > 0 Then
                'Agrego un Item más
                Dim dr As DataRow = dts.NewRow
                dr("cdCateg") = 0
                dr("dsNombre") = "TODOS"
                dts.Rows.InsertAt(dr, 0)

                cboRubro.DataSource = dts
                cboRubro.DataValueField = "cdCateg"
                cboRubro.DataTextField = "dsNombre"
                cboRubro.DataBind()
                dbDatos = Nothing
            Else
                Err.Raise(9000, "General.CargarRubros", "No hay rubros en la base de datos.")
            End If

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub CargarCboSubCategorias(ByRef cboCateg As DropDownList, ByRef dsPadre As String)
        Try
            Dim dt As DataTable
            Dim dbDatos As New NegEconomato.Categorizacion

            cboCateg.DataSource = dbDatos.ListarCategorizacionesAll(dsPadre)
            cboCateg.DataBind()
            dbDatos = Nothing

            If cboCateg.Items.Count = 0 Then
                cboCateg.Enabled = False
            Else
                cboCateg.Enabled = True
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboIngredientes(ByRef cboCombo As DropDownList, ByRef dsPadre As String)
        Try
            Dim dt As DataTable
            Dim dbDatos As New NegEconomato.Categorizacion

            cboCombo.DataSource = dbDatos.TraerIngredientes(dsPadre)
            cboCombo.DataBind()
            dbDatos = Nothing

            If cboCombo.Items.Count = 0 Then
                cboCombo.Enabled = False
            Else
                cboCombo.Enabled = True
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarCboIngredientesbySubCateg(ByVal cboCombo As DropDownList, ByVal dsPadre As String)
        Try
            Dim dt As DataTable
            Dim dbDatos As New NegEconomato.Categorizacion

            cboCombo.DataSource = dbDatos.TraerIngredientesbySubCateg(dsPadre)
            cboCombo.DataBind()
            dbDatos = Nothing

            If cboCombo.Items.Count = 0 Then
                cboCombo.Enabled = False
            Else
                cboCombo.Enabled = True
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarUnidadesIngredientes(ByRef cboUnidades As DropDownList)
        Try
            Dim dt As DataTable
            Dim oCateg As New NegEconomato.Categorizacion

            dt = oCateg.ListarUnidadesIngredientes
            cboUnidades.DataSource = dt
            cboUnidades.DataBind()
            oCateg = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarUnidadesPresentacion(ByRef cboUnidad As DropDownList, ByVal dsCodigoDesc As String)
        Try
            Dim ds As New DataSet
            Dim oCategorias As New NegEconomato.Categorizacion
            ds = oCategorias.SelectUnidadesPresentacion(dsCodigoDesc)

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    cboUnidad.DataSource = ds.Tables(0)
                    cboUnidad.DataBind()
                    cboUnidad.Enabled = True
                Else
                    cboUnidad.Enabled = False
                    cboUnidad.Items.Clear()
                End If
            End If
            oCategorias = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarTipoPlatosBusqueda(ByRef cboPlato As DropDownList)
        Try
            Dim ds As New DataSet
            Dim oPlato As New NegEconomato.Plato
            ds = oPlato.BuscarTipos(1)
            cboPlato.DataSource = ds.Tables(0)
            cboPlato.DataBind()
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarTipoPlatosIngreso(ByRef cboPlato As DropDownList)
        Try
            Dim ds As New DataSet
            Dim oPlato As New NegEconomato.Plato
            ds = oPlato.BuscarTipos(0)
            cboPlato.DataSource = ds.Tables(0)
            cboPlato.DataValueField = "cdCodigo"
            cboPlato.DataTextField = "dsDetalle"
            cboPlato.DataBind()
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarPlatoPrincipal(ByRef cboPlatoPrincipal As DropDownList)
        Try
            Dim oPlato As New NegEconomato.Plato
            Dim ds As DataTable

            ds = oPlato.ObtenerPlatosByTipo(2)
            If ds.Rows.Count > 0 Then
                cboPlatoPrincipal.DataSource = ds
                cboPlatoPrincipal.DataValueField = "cdPlato"
                cboPlatoPrincipal.DataTextField = "dsPlato"
                cboPlatoPrincipal.DataBind()
            End If
            oPlato = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarTipoComprobantes(ByRef cboTipo As DropDownList)
        Try
            Dim Comprobante As New NegEconomato.Comprobante
            Dim ds As DataTable

            ds = Comprobante.ObtenerTipoComprobantes()
            If ds.Rows.Count > 0 Then
                cboTipo.DataSource = ds
                cboTipo.DataValueField = "cdTipoMovimiento"
                cboTipo.DataTextField = "dsDescripcion"
                cboTipo.DataBind()
            End If

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Public Sub CargarTipoComprobantesProvisorios(ByVal cboTipo As DropDownList)
        Try
            Dim oMovimiento As New NegEconomato.Movimientos
            cboTipo.DataSource = oMovimiento.SelectTipoMovimientosProvisorios()
            cboTipo.DataValueField = "cdTipoMovimiento"
            cboTipo.DataTextField = "dsDescripcion"
            cboTipo.DataBind()
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub CargarTipoComprobantesDefinitivos(ByVal cboTipo As DropDownList, Optional ByVal blTodos As Boolean = False)
        Dim oMovimiento As New NegEconomato.Movimientos
        Dim dt As DataTable = oMovimiento.SelectTiposMovimientosDefinitivos()
        Dim dr As DataRow = dt.NewRow
        dr(0) = 0
        dr(1) = "Todos"
        If blTodos Then
            dt.Rows.InsertAt(dr, 0)
        End If
        cboTipo.DataSource = dt
        cboTipo.DataValueField = "cdTipoMovimiento"
        cboTipo.DataTextField = "dsDescripcion"
        cboTipo.DataBind()
    End Sub

    Public Sub CargarPeriocidad(ByVal cboPeriocidad As DropDownList)
        Try
            Dim oPlanillas As New NegEconomato.PlanillaSemanalConfiguracion
            cboPeriocidad.DataValueField = "cdCodigo"
            cboPeriocidad.DataTextField = "dsDetalle"
            cboPeriocidad.DataSource = oPlanillas.SelectPeriocidad
            cboPeriocidad.DataBind()
            oPlanillas = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarCboCategorias(ByRef cboCateg As DropDownList, ByRef cboRubros As DropDownList)
        Try
            Dim dt As DataTable
            Dim dbDatos1 As New NegEconomato.Categorizacion
            dt = dbDatos1.ListarCategorizacionesAll(cboRubros.SelectedValue)
            cboCateg.DataSource = dt
            cboCateg.DataBind()
            dbDatos1 = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub CargarCboDosificaciones(ByRef cboDosif As DropDownList)
        Try
            Dim oDos As New NegEconomato.Dosificacion
            cboDosif.DataSource = oDos.SelectDosificacionesAll
            cboDosif.DataValueField = "cdNroDosif"
            cboDosif.DataTextField = "dtFecha"
            cboDosif.DataBind()
            oDos = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub

    Public Sub LeerXml(ByVal S As String)
        Dim xml As New System.Xml.XmlDocument

        xml.LoadXml("<Platos>" & S & "</Platos>")


    End Sub
End Module
