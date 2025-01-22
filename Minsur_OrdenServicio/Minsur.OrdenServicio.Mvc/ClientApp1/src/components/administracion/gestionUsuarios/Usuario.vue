<template>
  <div>
    <div class="row">
      <div class="ibox-title">
        <h5>:: CRITERIOS DE BÚSQUEDA</h5>
      </div>
      <div class="ibox-content m-b-sm border-bottom">
        <div class="row">
          <div class="col-lg-6">
            <div class="form-group">
              <label class="control-label" for="username">Usuario</label>
              <input
                type="text"
                name="username"
                v-model="username"
                class="form-control"
                 v-on:keyup.enter="buscar"
              />
            </div>
          </div>
          <div class="col-lg-6">
            <div class="form-group">
              <label class="control-label" for="nombre">Nombre</label>
              <input
                type="text"
                name="nombre"
                v-model="nombre"
                class="form-control"
                 v-on:keyup.enter="buscar"
              />
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-lg-12">
            <div class="text-right">
              <button class="btn btn-primary btn-buscar" @click="buscar">
                <i class="fa fa-search"></i>
                <strong>Buscar</strong>
              </button>
              <button class="btn btn-primary" @click="nuevo">
                <i class="fa fa-square-plus"></i>
                <strong>Nuevo</strong>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="ibox-title">
        <h5>RESULTADOS DE BÚSQUEDA</h5>
      </div>
      <div class="ibox-content m-b-sm border-bottom">
        <el-table
          :data="listaUsuarios"
          row-key="idUsuario"
          v-loading="isLoading"
          :header-row-style="tableHeaderColor"
        >
          <el-table-column
            prop="nombreUsuario"
            label="Usuario"
          ></el-table-column>
          <el-table-column
            prop="nombreApellido"
            label="Nombres / Apellidos"
          ></el-table-column>
          <el-table-column prop="correo" label="Correo"></el-table-column>
          <el-table-column prop="estado" label="Estado"></el-table-column>
          <el-table-column prop="editar" label="Editar">
            <template slot-scope="scope">
              <el-button size="mini" type="primary" @click="editar(scope.row)"
                >Editar</el-button
              >
            </template>
          </el-table-column>
        </el-table>
        <el-pagination
          @current-change="handleCurrentChange"
          :current-page.sync="paginaActual"
          :page-size="nroFilasPorPagina"
          layout="total, prev, pager, next"
          :total="total"
        ></el-pagination>
      </div>
    </div>
    <el-dialog
      :visible.sync="mantenimientoUsuarioPopUpVisible"
      :show-close="false"
      width="80%"
      custom-class="custom-dialog"
    >
      <h2 slot="title">:: Nuevo Usuario</h2>
      <mantenimiento-usuario
        v-bind:usuario="usuarioSeleccionado"
        v-bind:nuevoUsuario="nuevoUsuario"
        @cerrarPopUp="cerrarMantenimientoPopUp"
        @guardar="guardarConfiguracionUsuario"
      />
    </el-dialog>
  </div>
</template>
<script>
import AdministracionService from "@/services/administracion.service";
import SwalAlert from "@/common/swal.alert";
import MantenimientoUsuario from "@/components/administracion/gestionUsuarios/mantenimientos/MantenimientoUsuario";
import sharedFunctions from "@/common/functions";

export default {
  name: "usuario",
  components: {
    MantenimientoUsuario
  },
  created() {
    this.tableHeaderColor = sharedFunctions.tableHeaderColorBlack;
  },
  data() {
    return {
      isLoading: false,
      username: "",
      nombre: "",
      listaUsuarios: [],
      total: 0,
      paginaActual: 0,
      nroFilasPorPagina: 0,
      mantenimientoUsuarioPopUpVisible: false,
      usuarioSeleccionado: {},
      nuevoUsuario: false
    };
  },
  methods: {
    buscar() {
      this.obtenerUsuarios();
    },
    obtenerUsuarios(nroPagina = 1) {
      this.isLoading = true;
      AdministracionService.obtenerUsuarios({
        usuario: this.username,
        nombre: this.nombre,
        nroPagina: nroPagina
      })
        .then(response => {
          this.listaUsuarios = response.data.listaUsuarios;
          this.total = response.data.total;
          this.nroFilasPorPagina = response.data.nroFilasPorPagina;
          this.paginaActual = nroPagina;
        })
        .finally(() => (this.isLoading = false));
    },
    handleCurrentChange(nroPagina) {
      this.obtenerUsuarios(nroPagina);
    },
    nuevo() {
      this.usuarioSeleccionado = {
        idUsuario: 0,
        correo: "",
        nombreApellido: "",
        nombreUsuario: "",
        idEstado: 1,
        idRol: 0,
      };
      this.nuevoUsuario = true;
      this.mantenimientoUsuarioPopUpVisible = true;
    },
    editar(usuario) {
      this.nuevoUsuario = false;
      this.usuarioSeleccionado = usuario;
      this.mantenimientoUsuarioPopUpVisible = true;
    },
    cambiarEstado(usuario, idEstado) {
      this.isLoading = true;
      usuario.idEstado = idEstado;
      AdministracionService.editarUsuario(usuario).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(response.data.mensaje, this.obtenerUsuarios);
      });
    },
    guardarConfiguracionUsuario(
      usuario,
      listaConfiguracionUsuarioProyecto,
      nuevoUsuario
    ) {
      if (nuevoUsuario) {
        this.registrarUsuario(usuario);
      } else {
        this.guardarConfiguracionUsuarioProyecto(
          usuario,
          listaConfiguracionUsuarioProyecto
        );
      }
    },
    registrarUsuario(usuario) {
      AdministracionService.registrarUsuario(usuario).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarMantenimientoPopUpGuardar
        );
      });
    },
    guardarConfiguracionUsuarioProyecto(usuario, listaConfiguracionUsuarioProyecto) {
      let configuracionUsuarioProyectoRequest = {
        listaConfiguracionUsuarioProyectoDto: listaConfiguracionUsuarioProyecto,
        idUsuario: usuario.idUsuario,
        idRol: usuario.idRol,
        idEstado: usuario.idEstado
      };
      configuracionUsuarioProyectoRequest.listaConfiguracionUsuarioProyectoDto.map(
        item => {
          item.idEstado = item.idEstado ? 1 : 0;
        }
      );
      AdministracionService.guardarConfiguracionUsuarioProyecto(
        configuracionUsuarioProyectoRequest
      ).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarMantenimientoPopUpGuardar
        );
      });
    },
    cerrarMantenimientoPopUp() {
      this.mantenimientoUsuarioPopUpVisible = false;
    },
    cerrarMantenimientoPopUpGuardar() {
      this.obtenerUsuarios(1);
      this.mantenimientoUsuarioPopUpVisible = false;
    }
  }
};
</script>