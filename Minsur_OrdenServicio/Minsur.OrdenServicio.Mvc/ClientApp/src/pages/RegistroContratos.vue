<template>
    <div>
      <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-12">
          <h2>Contratos</h2>
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
                      <th data-toggle="true" class="text-center">Código de Contrato</th>
                      <th data-hide="phone" class="text-center">Proveedor</th>
                      <th data-hide="phone" class="text-center">Proyecto</th>
                      <th data-hide="phone" class="text-center">Denominación del Contrato</th>
                      <th data-hide="phone" class="text-center">Monto del Contrato</th>
                      <th data-hide="phone" class="text-center">Acciones</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(contrato, index) in contratos" :key="index">
                      <td class="text-center">{{ contrato.codigo }}</td>
                      <td class="text-center">{{ contrato.contratista.codigo }} - {{ contrato.contratista.nombre }}</td>
                      <td class="text-center">{{ getProyectoNombre(contrato.proyecto) }}</td>
                      <td class="text-center">{{ contrato.denominacion }}</td>
                      <td class="text-center">{{ contrato.monto }}</td>
                      <td class="text-center">
                        <button class="btn btn-success" @click="editContrato(index)"><i class="fa fa-edit"></i></button>
                        <button class="btn btn-danger" @click="deleteContrato(index)"><i class="fa fa-trash"></i></button>
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
        <h2 slot="title">{{ isEditing ? 'Editar Contrato' : 'Agregar Contrato' }}</h2>
        <form @submit.prevent="handleSubmit">
          <div class="form-group">
            <label class="control-label" for="codigo">Código de Contrato:</label>
            <input
              type="text"
              name="codigo"
              v-model="contrato.codigo"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label class="control-label" for="contratista">Proveedor:</label>
            <select
              class="form-control"
              v-model="contrato.contratista.codigo"
              required
            >
              <option
                v-for="item in contratistas"
                v-bind:value="item.codigo"
                :key="item.codigo">{{ item.nombre }}</option>
            </select>
            <!-- <el-select v-model="contrato.contratista.codigo" placeholder="Seleccione un contratista" required>
              <el-option
                v-for="item in contratistas"
                :key="item.codigo"
                :label="item.nombre"
                :value="item.codigo"
              ></el-option>
            </el-select> -->
          </div>
          <div class="form-group">
            <label class="control-label" for="proyecto">Proyecto:</label>
            <select
              class="form-control"
              v-model="contrato.proyecto"
              required
            >
              <option
                v-for="item in proyectos"
                v-bind:value="item.id"
                :key="item.id">{{ item.nombre }}</option>
            </select>
          </div>
          <div class="form-group">
            <label class="control-label" for="denominacion">Denominación del Contrato:</label>
            <input
              type="text"
              name="denominacion"
              v-model="contrato.denominacion"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label class="control-label" for="monto">Monto del Contrato:</label>
            <input
              type="number"
              name="monto"
              v-model="contrato.monto"
              class="form-control"
              required
            />
          </div>
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
        contratos: [],
        dialogVisible: false,
        isEditing: false,
        contrato: {
          codigo: '',
          contratista: {
            codigo: '',
            nombre: ''
          },
          proyecto: '',
          denominacion: '',
          monto: ''
        },
        contratistas: [
          { codigo: 'C001', nombre: 'Proveedor A' },
          { codigo: 'C002', nombre: 'Proveedor B' },
          { codigo: 'C003', nombre: 'Proveedor C' }
        ],
        proyectos: [
          { id: 1, nombre: 'Proyecto A' },
          { id: 2, nombre: 'Proyecto B' },
          { id: 3, nombre: 'Proyecto C' }
        ],
        total: 0,
        paginaActual: 0,
        nroFilasPorPagina: 0
      };
    },
    methods: {
      openDialog() {
        this.contrato = { codigo: '', contratista: { codigo: '', nombre: '' }, proyecto: '', denominacion: '', monto: '' };
        this.isEditing = false;
        this.dialogVisible = true;
      },
      closeDialog() {
        this.dialogVisible = false;
      },
      handleSubmit() {
        if (this.isEditing) {
          const index = this.contratos.findIndex(c => c.codigo === this.contrato.codigo);
          this.$set(this.contratos, index, { ...this.contrato });
        } else {
          const contratistaSeleccionado = this.contratistas.find(c => c.codigo === this.contrato.contratista.codigo);
          this.contrato.contratista.nombre = contratistaSeleccionado ? contratistaSeleccionado.nombre : '';
          this.contratos.push({ ...this.contrato });
        }
        this.closeDialog();
      },
      editContrato(index) {
        this.contrato = { ...this.contratos[index] };
        this.isEditing = true;
        this.dialogVisible = true;
      },
      deleteContrato(index) {
        this.contratos.splice(index, 1);
      },
      getProyectoNombre(id) {
        const proyecto = this.proyectos.find(p => p.id === id);
        return proyecto ? proyecto.nombre : 'N/A';
      },
      handleCurrentChange(nroPagina) {
        console.log(nroPagina);
      },
    }
  };
  </script>
  
  <style scoped>
  .text-right {
    text-align: right;
  }
  </style>