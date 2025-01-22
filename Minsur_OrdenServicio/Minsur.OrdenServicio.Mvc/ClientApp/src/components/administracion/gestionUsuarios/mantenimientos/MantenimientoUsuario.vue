<template>
  <div class="row">
    <div class="col-lg-6">
      <div class="ibox float-e-margins">
        <div class="ibox-title">
          <h5>Datos de usuario</h5>
        </div>
      </div>
      <div class="ibox-content m-b-sm">
        <div class="row">
          <div class="form-group">
            <label class="control-label" for="correo">Correo</label>
            <input
              type="text"
              name="correo"
              v-model="usuario.correo"
              class="form-control"
              :readonly="!datosUsuarioHabilitados"
            />
          </div>
          <div class="form-group">
            <label class="control-label" for="nombreApellido"
              >Nombres Completos</label
            >
            <input
              type="text"
              name="nombreApellido"
              v-model="usuario.nombreApellido"
              class="form-control"
              :readonly="!datosUsuarioHabilitados"
            />
          </div>
          <div class="form-group">
            <label class="control-label" for="nombreUsuario">Usuario</label>
            <input
              type="text"
              name="nombreUsuario"
              v-model="usuario.nombreUsuario"
              class="form-control"
              :readonly="!datosUsuarioHabilitados"
            />
          </div>
          <div class="form-group">
            <label class="control-label" for="estado">Estado</label>
            <select
              name="estado"
              class="form-control"
              v-model="usuario.idEstado"
            >
              <option
                v-for="item in listaEstados"
                v-bind:value="item.idEstado"
                :key="item.idEstado"
              >
                {{ item.estado }}
              </option>
            </select>
          </div>
          <div class="form-group">
            <label class="control-label" for="rol">Perfil</label>
            <select name="rol" class="form-control" v-model="usuario.idRol">
              <option
                v-for="item in listaRoles"
                v-bind:value="item.idRol"
                :key="item.idRol"
              >
                {{ item.nombre }}
              </option>
            </select>
          </div>
        </div>
      </div>
    </div>
    <div
      class="col-lg-6"
      v-bind:class="{ disabled: !asignarProyectoHabilitado }"
    >
      <div class="ibox float-e-margins">
        <div class="ibox-title">
          <h5>Asignar proyecto</h5>
        </div>
      </div>
      <div class="ibox-content m-b-sm">
        <div class="row" v-loading="isLoading">
          <div class="form-group">
            <label class="control-label" for="compania">Compañía</label>
            <select
              name="compania"
              class="form-control"
              v-model="idCompaniaSeleccionada"
              :disabled="!asignarProyectoHabilitado"
              @change="obtenerListaConfiguracionUsuarioProyecto"
            >
              <option
                v-for="item in listaCompanias"
                :value="item.idCompania"
                :key="item.idCompania"
                >{{ item.descripcion }}</option
              >
            </select>
          </div>
        </div>
        <div class="row" v-loading="isConfiguracionProyectosLoading">
          <div class="table-responsive m-t">
            <table class="table table-striped custom-table">
              <thead>
                <tr>
                  <th class="text-center">Proyecto</th>
                  <th class="text-center">Asignar</th>
                  <th class="text-center">Visualizar otros</th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(item, index) in listaConfiguracionUsuarioProyecto"
                  :key="index"
                >
                  <td>{{ item.proyectoDto.descripcion }}</td>
                  <td class="text-center">
                    <input type="checkbox" v-model="item.idEstado" />
                  </td>
                  <td class="text-center">
                    <input type="checkbox" v-model="item.flagConsultaOtros" />
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-lg-12">
        <label class="control-label" style="display:block;" for>&nbsp;</label>
        <div class="text-right">
          <button class="btn btn-primary" type="button" @click="guardar">
            <i class="fa fa-save">&nbsp; Guardar</i>
          </button>
          <button class="btn btn-primary" type="button" @click="cerrarPopUp">
            <i class="fa fa-reply">&nbsp; Cancelar</i>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import {
  ESTADOS_SEGURIDAD,
  ESTADOS_GENERALES
} from "@/constants/maestro.constants";
import AdministracionService from "@/services/administracion.service";

export default {
  name: "mantenimiento-usuario",
  props: {
    usuario: Object,
    nuevoUsuario: Boolean
  },
  data() {
    return {
      listaEstados: [],
      listaCompanias: [],
      listaRoles: [],
      listaConfiguracionUsuarioProyecto: [],
      idCompaniaSeleccionada: 0,
      isLoading: false,
      isConfiguracionProyectosLoading: false
    };
  },
  computed: {
    datosUsuarioHabilitados() {
      return this.usuario.idUsuario === 0;
    },
    asignarProyectoHabilitado() {
      return this.usuario.idUsuario !== 0;
    }
  },
  mounted() {
    this.$watch(
      "usuario",
      usuario => {
        this.inicializar();
      },
      { inmediate: true }
    );
    this.inicializar();
    this.obtenerEstados();
  },
  methods: {
    inicializar() {
      this.obtenerCompaniasActivas();
      this.obtenerRoles();
    },
    obtenerCompaniasActivas() {
      this.isLoading = true;
      this.listaConfiguracionUsuarioProyecto = [];
      AdministracionService.obtenerCompanias()
        .then(
          response =>
            (this.listaCompanias = response.data.listaCompanias.filter(
              compania => compania.idEstado === ESTADOS_GENERALES.ACTIVO
            ))
        )
        .then(() =>
          this.listaCompanias.unshift({
            idCompania: 0,
            idEstado: ESTADOS_GENERALES.ACTIVO,
            descripcion: ":: SELECCIONE ::"
          })
        )
        .then(
          () =>
            (this.idCompaniaSeleccionada = this.listaCompanias[0].idCompania)
        )
        .finally(() => (this.isLoading = false));
    },
    obtenerRoles() {
      AdministracionService.obtenerRoles()
        .then(response => (this.listaRoles = response.data.listaRoles))
        .then(() => {
          this.usuario.idRol =
            this.usuario.idRol === 0
              ? this.listaRoles[0].idRol
              : this.usuario.idRol;
        });
    },
    obtenerListaConfiguracionUsuarioProyecto() {
      if (this.idCompaniaSeleccionada === 0) {
        this.listaConfiguracionUsuarioProyecto = [];
        return;
      }
      this.isConfiguracionProyectosLoading = true;
      AdministracionService.obtenerListaConfiguracionUsuarioProyecto({
        idCompania: this.idCompaniaSeleccionada,
        idUsuario: this.usuario.idUsuario
      })
        .then(
          response =>
            (this.listaConfiguracionUsuarioProyecto =
              response.data.listaConfiguracionUsuarioProyecto)
        )
        .finally(() => (this.isConfiguracionProyectosLoading = false));
    },
    obtenerEstados() {
      this.listaEstados = ESTADOS_SEGURIDAD.LISTADO;
    },
    cerrarPopUp() {
      this.$emit("cerrarPopUp");
    },
    guardar() {
      this.$emit(
        "guardar",
        this.usuario,
        this.listaConfiguracionUsuarioProyecto,
        this.nuevoUsuario
      );
    }
  }
};
</script>
<style>
.disabled {
  opacity: 0.6;
}
</style>