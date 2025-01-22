<template>
    <div>
      <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-12">
          <h2>Proveedores</h2>
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
      <div class="col-lg-11"></div>
      <div class="col-lg-1">
          <button class="btn btn-success" @click="openDialog"><i class="fa fa-plus"></i></button>
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
                      <th data-toggle="true" class="text-center">Código</th>
                      <!-- <th data-hide="phone" class="text-center">RUC</th> -->
                      <th data-hide="phone" class="text-center">Razón Social</th>
                      <!-- <th data-hide="phone" class="text-center">Proyecto</th> -->
                      <th data-hide="phone" class="text-center">Acciones</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(contratista, index) in contratistas" :key="index">
                      <td class="text-center">{{ contratista.codigo }}</td>
                      <!-- <td class="text-center">{{ contratista.ruc }}</td> -->
                      <td class="text-center">{{ contratista.razonSocial }}</td>
                      <!-- <td class="text-center">{{ getProyectoNombre(contratista.proyecto) }}</td> -->
                      <td class="text-center">
                        <button class="btn btn-success" @click="editContratista(index)"><i class="fa fa-edit"></i></button>
                        <button class="btn btn-danger" @click="deleteContratista(index)"><i class="fa fa-trash"></i></button>
                      </td>
                    </tr>
                  </tbody>
                </table>
                <el-pagination @current-change="handleCurrentChange" :current-page.sync="paginaActual" :page-size="nroFilasPorPagina" layout="total, prev, pager, next" :total="total">
                </el-pagination>
              </div>
            </div>
          </div>
        </div>
      </div>
  
        <el-dialog
            :visible.sync="dialogVisible"
            width="30%"
            top="3vh"
            custom-class="custom-dialog"
            >
            <h2 slot="title">{{ isEditing ? 'Editar' : 'Agregar' }}</h2>
            <form @submit.prevent="handleSubmit">
                <div class="form-group">
                    <label class="control-label" for="codigo">Código SAP:</label>
                    <input
                        type="text"
                        name="codigo"
                        v-model="contratista.codigo"
                        class="form-control"
                        required
                    />
                </div>
                <!-- <div class="form-group">
                    <label class="control-label" for="ruc">RUC:</label>
                    <input
                        type="text"
                        name="ruc"
                        v-model="contratista.ruc"
                        class="form-control"
                        required
                    />
                </div> -->
                <div class="form-group">
                    <label class="control-label" for="razonSocial">Razón Social:</label>
                    <input
                        type="text"
                        name="razonSocial"
                        v-model="contratista.razonSocial"
                        class="form-control"
                        required
                    />
                </div>
                <!-- <div class="form-group">
                    <label class="control-label" for="estado">Proyecto:</label>
                    <select
                        class="form-control"
                        v-model="contratista.proyecto"
                        required
                    >
                        <option
                        v-for="item in proyectos"
                        v-bind:value="item.id"
                        :key="item.id"
                        >{{item.nombre}}</option>
                    </select>
                </div> -->
                <span slot="footer" class="dialog-footer">
                    <br>
                    <div class="text-right">
                        <el-button class="btn btn-primary" @click="closeDialog">Cancelar</el-button>
                        <el-button class="btn btn-primary" type="primary" native-type="submit">{{ isEditing ? 'Actualizar' : 'Agregar' }}</el-button>
                    </div>
                </span>
            </form>
        </el-dialog>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        contratistas: [],
        dialogVisible: false,
        isEditing: false,
        contratista: {
          codigo: '',
          ruc: '',
          razonSocial: '',
          proyecto: ''
        },
        proyectos: [
          { id: 1, nombre: 'Proyecto A' },
          { id: 2, nombre: 'Proyecto B' },
          { id: 3, nombre: 'Proyecto C' }
        ],
        total: 0,
        paginaActual:0,
        nroFilasPorPagina: 0
      };
    },
    methods: {
      openDialog() {
        this.contratista = { codigo: '', ruc: '', razonSocial: '', proyecto: '' };
        this.isEditing = false;
        this.dialogVisible = true;
      },
      closeDialog() {
        this.dialogVisible = false;
      },
      handleSubmit() {
        if (this.isEditing) {
          const index = this.contratistas.findIndex(c => c.codigo === this.contratista.codigo);
          this.$set(this.contratistas, index, { ...this.contratista });
        } else {
          this.contratistas.push({ ...this.contratista });
        }
        this.closeDialog();
      },
      editContratista(index) {
        this.contratista = { ...this.contratistas[index] };
        this.isEditing = true;
        this.dialogVisible = true;
      },
      deleteContratista(index) {
        this.contratistas.splice(index, 1);
      },
      getProyectoNombre(id) {
        const proyecto = this.proyectos.find(p => p.id === id);
        return proyecto ? proyecto.nombre : 'N/A';
      },
      handleCurrentChange(nroPagina) {
            console.log(nroPagina)
        },
    }
  };
  </script>
  
  <style scoped>
    .text-right {
        text-align: right;
    }
  </style>