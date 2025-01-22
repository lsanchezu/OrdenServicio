<template>
    <div>
      <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-12">
          <h2>Consultar Orden de Cambio</h2>
          <ol class="breadcrumb">
            <li>
              <a href="">Home</a>
            </li>
            <li>
              <a>Reporte</a>
            </li>
            <li class="active">
              <strong>Consulta</strong>
            </li>
          </ol>
        </div>
      </div>
      <br>
      <div class="row">
        <div class="col-lg-12">
          <br>
          <div class="ibox-title">
            <h5>:: RESULTADOS DE LA BÚSQUEDA</h5>
          </div>
          <div class="ibox">
            <div class="ibox-content">
              <div class="table-responsive m-t">
                <table class="table table-striped custom-table">
                  <thead>
                    <tr>
                      <th class="text-center">Nro. Orden</th>
                      <th class="text-center">Compañía</th>
                      <th class="text-center">Contrato</th>
                      <th class="text-center">Proyecto</th>
                      <th class="text-center">Fecha Solicitud</th>
                      <th class="text-center">Estado</th>
                      <th class="text-center">Acciones</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(solicitud, index) in paginatedSolicitudes" :key="index">
                      <td class="text-center">{{ solicitud.numero }}</td>
                      <td class="text-center">{{ solicitud.compania }}</td>
                      <td class="text-center">{{ solicitud.contrato }}</td>
                      <td class="text-center">{{ solicitud.proyecto }}</td>
                      <td class="text-center">{{ solicitud.fecha }}</td>
                      <td class="text-center">
                        <span :class="getStatusClass(solicitud.estado)">{{ solicitud.estado }}</span>
                      </td>
                      <td class="text-center">
                        <button class="btn btn-info" @click="openDetailModal(solicitud)"><i class="fa fa-eye"></i> Ver</button>
                        <button class="btn btn-info" v-if="solicitud.estado === 'Completado' || solicitud.estado === 'Rechazado' " @click="descargarPdf()" ><i class="fa fa-file-pdf-o"></i></button>
                      </td>
                    </tr>
                  </tbody>
                </table>
                <el-pagination
                  @current-change="handleCurrentChange"
                  :current-page.sync="paginaActual"
                  :page-size="nroFilasPorPagina"
                  layout="total, prev, pager, next"
                  :total="total"
                >
                </el-pagination>
              </div>
            </div>
          </div>
        </div>
      </div>
  
      <el-dialog
        :visible.sync="detailDialogVisible"
        width="50%"
        top="3vh"
        custom-class="custom-dialog"
      >
        <h2 slot="title">Orden de Cambio</h2>
        <div class="row">
          <div class="col-sm-6">
            <div class="form-group">
              <label>Denominación del Proveedor:</label>
              <input type="text" v-model="selectedSolicitud.contratista" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Fecha Solicitud:</label>
              <input type="text" v-model="selectedSolicitud.fecha" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Compañía:</label>
              <input type="text" v-model="selectedSolicitud.compania" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Proyecto:</label>
              <input type="text" v-model="selectedSolicitud.proyecto" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Contratos:</label>
              <input type="text" v-model="selectedSolicitud.contrato" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Denominación del Contrato:</label>
              <input type="text" v-model="selectedSolicitud.denominacion" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Requerida Por:</label>
              <input type="text" v-model="selectedSolicitud.requeridaPor" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Nombre del Solicitante:</label>
              <input type="text" v-model="selectedSolicitud.solicitante" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Número de Solicitud:</label>
              <input type="text" v-model="selectedSolicitud.numero" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Monto de la Solicitud de Cambio:</label>
              <input type="text" v-model="selectedSolicitud.montoCambio" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Impacto:</label>
              <input type="text" v-model="selectedSolicitud.impacto" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Detalle de la Solicitud:</label>
              <input type="text" v-model="selectedSolicitud.detalle" class="form-control" readonly>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="form-group">
              <label>Diferencia de Monto:</label>
              <input type="text" :value="selectedSolicitud.montoCambio - selectedSolicitud.montoInicial" class="form-control" readonly>
            </div>
          </div>
        </div>
        <table class="table custom-table">
          <thead>
              <tr>
                  <th class="text-left"><strong>Resumen del valor contractual</strong></th>
                  <th></th>
                  <th></th>
              </tr>
          </thead>
          <tbody>
              <tr>
                  <td>Valor original del contrato</td>
                  <td>USD</td>
                  <td>3403.00</td>
              </tr>
              <tr>
                  <td>Ordenes de cambio acumuladas</td>
                  <td>USD</td>
                  <td>5237.00</td>
              </tr>
              <tr>
                  <td>Valor de esta orden de cambio</td>
                  <td>USD</td>
                  <td>12692.00</td>
              </tr>
              <tr>
                  <td>Nuevo valor contractual</td>
                  <td>USD</td>
                  <td>21332.00</td>
              </tr>
              <tr>
                  <th>Indicador porcentual de cambios aprobados a la fecha</th>
                  <th></th>
                  <th>526.9%</th>
              </tr>
          </tbody>
      </table>
        <div class="form-group" v-if="selectedSolicitud.archivos && selectedSolicitud.archivos.length">
          <label>Descargar Archivos:</label>
          <ul>
            <li v-for="(archivo, index) in selectedSolicitud.archivos" :key="index">
              <a :href="archivo.url" download>{{ archivo.nombre }}</a>
            </li>
          </ul>
        </div>
        <span slot="footer" class="dialog-footer">
          <el-button @click="closeDetailModal">Cerrar</el-button>
        </span>
      </el-dialog>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        solicitudes: [
          {
            numero: '001',
            compania: 'Compañía A',
            contrato: 'Contrato A',
            proyecto: 'Proyecto A',
            fecha: '2023-10-01',
            contratista: 'Proveedor A',
            denominacion: 'Denominación A',
            requeridaPor: 'Usuario A',
            solicitante: 'Solicitante A',
            montoCambio: 5000,
            montoInicial: 3000,
            impacto: 'Alto',
            detalle: 'Cambio en el alcance del proyecto.',
            estado: 'Pendiente',
            archivos: [
              { nombre: 'Documento1.pdf', url: '/path/to/documento1.pdf' },
              { nombre: 'Documento2.pdf', url: '/path/to/documento2.pdf' }
            ]
          },
          {
            numero: '002',
            compania: 'Compañía B',
            contrato: 'Contrato B',
            proyecto: 'Proyecto B',
            fecha: '2023-10-02',
            contratista: 'Proveedor B',
            denominacion: 'Denominación B',
            requeridaPor: 'Usuario B',
            solicitante: 'Solicitante B',
            montoCambio: 3000,
            montoInicial: 2000,
            impacto: 'Medio',
            detalle: 'Ajuste en el presupuesto.',
            estado: 'Completado',
            archivos: []
          },
          {
            numero: '003',
            compania: 'Compañía C',
            contrato: 'Contrato C',
            proyecto: 'Proyecto C',
            fecha: '2023-10-03',
            contratista: 'Proveedor C',
            denominacion: 'Denominación C',
            requeridaPor: 'Usuario C',
            solicitante: 'Solicitante C',
            montoCambio: 7000,
            montoInicial: 5000,
            impacto: 'Bajo',
            detalle: 'Revisión de costos.',
            estado: 'Rechazado',
            archivos: []
          },
          // Agrega más solicitudes según sea necesario
        ],
        detailDialogVisible: false,
        selectedSolicitud: {},
        paginaActual: 1,
        nroFilasPorPagina: 5,
      };
    },
    computed: {
      total() {
        return this.solicitudes.length;
      },
      paginatedSolicitudes() {
        const start = (this.paginaActual - 1) * this.nroFilasPorPagina;
        return this.solicitudes.slice(start, start + this.nroFilasPorPagina);
      }
    },
    methods: {
      openDetailModal(solicitud) {
        this.selectedSolicitud = solicitud;
        this.detailDialogVisible = true;
      },
      closeDetailModal() {
        this.detailDialogVisible = false;
      },
      approveSolicitud() {
        const index = this.solicitudes.indexOf(this.selectedSolicitud);
        if (index !== -1) {
          this.solicitudes.splice(index, 1);
        }
        this.closeDetailModal();
      },
      handleCurrentChange(newPage) {
        this.paginaActual = newPage;
      },
      descargarPdf() {
        console.log("PDF Descargado");
      },
      getStatusClass(estado) {
        switch (estado) {
          case 'Pendiente':
            return 'text-warning'; // Color ámbar
          case 'Completado':
            return 'text-success'; // Color verde
          case 'Rechazado':
            return 'text-danger'; // Color rojo
          default:
            return '';
        }
      }
    }
  };
  </script>
  
  <style scoped>
  .text-center {
    text-align: center;
  }
  .text-warning {
    color: #ffc107; /* Color ámbar */
  }
  .text-success {
    color: #28a745; /* Color verde */
  }
  .text-danger {
    color: #dc3545; /* Color rojo */
  }
  </style>