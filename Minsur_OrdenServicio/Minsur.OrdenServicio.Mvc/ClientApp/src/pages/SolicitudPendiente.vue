<template>
    <div>
      <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-12">
          <h2>Solicitudes de Cambio Pendientes</h2>
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
                      <th class="text-center">Nro. Solicitud</th>
                      <th class="text-center">Compañía</th>
                      <th class="text-center">Contrato</th>
                      <th class="text-center">Proyecto</th>
                      <th class="text-center">Fecha Solicitud</th>
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
                        <button class="btn btn-info" @click="openDetailModal(solicitud)"><i class="fa fa-eye"></i> Ver</button>
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
        <h2 slot="title">Detalle de la Solicitud</h2>
        <div class="row">
          <div class="col-sm-6">
            <div class="form-group">
              <label>Denominación del Proveedor</label>
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
          <div class="col-sm-12">
          <div class="form-group">
            <label class="control-label" for="txtComentario">Comentario</label> 
            <textarea name="txtComentario"  
                    rows="3" maxlength="1024" 
                    v-model="comentario" 
                    placeholder="Ingrese un comentario (cant. max. 1024)" 
                    spellcheck="true"
                    v-validate="'required'"
                    :class="{'form-control': true, 'error': errors.has('txtDenominacionServicio') }"
                    >
            </textarea>
            <label class="error" v-show="errors.has('txtDenominacionServicio')">{{ errors.first('txtDenominacionServicio') }}</label>
          </div>
        </div>
        </div>
        <!-- <div class="form-group">
          <label>Archivos Adjuntos:</label>
          <input type="file" multiple @change="handleFileUpload" class="form-control">
        </div> -->
        <div class="form-group" v-if="selectedSolicitud.archivos && selectedSolicitud.archivos.length">
          <label>Descargar Archivos:</label>
          <ul>
            <li v-for="(archivo, index) in selectedSolicitud.archivos" :key="index">
              <a :href="archivo.url" download>{{ archivo.nombre }}</a>
            </li>
          </ul>
        </div>

        
        <span slot="footer" class="dialog-footer">
          <el-button type="primary" @click="approveSolicitud">Aprobar</el-button>
          <el-button type="danger" @click="approveSolicitud">Rechazar</el-button>
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
            archivos: [
              { nombre: 'Documento1.pdf', url: '/path/to/documento1.pdf' },
              { nombre: 'Documento2.pdf', url: '/path/to/documento2.pdf' }
            ],
          },
          // Agrega más solicitudes según sea necesario
        ],
        detailDialogVisible: false,
        selectedSolicitud: {},
        paginaActual: 1,
        nroFilasPorPagina: 5,
        comentario: ""
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
      handleFileUpload(event) {
        const files = event.target.files;
        // Manejar la carga de archivos aquí
      }
    }
  };
  </script>
  
  <style scoped>
  .text-center {
    text-align: center;
  }
  </style>