<template>
  <div>
    <div class="row">
      <div class="ibox-title">
        <h5>Lista de Roles</h5>
      </div>
      <div class="ibox-content m-b-sm border-bottom">
        <div class="row" v-loading="isLoading">
          <div class="col-lg-3">
            <div class="form-group">
              <label class="control-label" for="compania">Compañía</label>
              <select
                name="compania"
                class="form-control"
                v-model="idCompaniaSeleccionada"
                @change="obtenerProyectosActivos"
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
          <div class="col-lg-3">
            <div class="form-group">
              <label class="control-label" for="proyecto">Proyecto</label>
              <select
                name="compania"
                class="form-control"
                v-model="idProyectoSeleccionado"
                @change="obtenerListaConfiguracionRol"
              >
                <option
                  v-for="item in listaProyectos"
                  :value="item.idProyecto"
                  :key="item.idProyecto"
                  >{{ item.descripcion }}</option
                >
              </select>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="form-group">
              <label class="control-label" style="display:block;">&nbsp;</label>
              <button
                class="btn btn-primary"
                title="Agregar Usuario"
                style="float:right;"
                @click="abrirAgregarRolUsuarioPopUp"
              >
                <i class="fa fa-plus-square"></i>
                &nbsp; Agregar Usuario
              </button>
            </div>
          </div>
        </div>
        <div class="row" v-loading="isListaConfiguracionRolLoading">
          <div class="table-responsive m-t">
            <table class="table table-striped custom-table">
              <thead>
                <tr>
                  <th>Usuario</th>
                  <th v-for="(rol, index) in listaRoles" :key="index">
                    {{ rol.descripcion }}
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(configuracion, index) in listaConfiguracionRolDto"
                  :key="index"
                >
                  <td>
                    {{ configuracion.usuarioDto.nombreUsuario }}
                  </td>

                  <td
                    v-for="(rol, index) in configuracion.listaRolGobernanzaDto"
                    :key="index"
                  >
                    <input type="checkbox" v-model="rol.idEstado" @change="gestionarCambioDisciplinas(configuracion,rol)" />
                    <button
                      v-if="rol.orden === 1 && rol.idEstado"
                      class="btn btn-sm btn-primary btn-buscar"
                      @click="verDisciplinas(configuracion)"
                    >
                      Asignar
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="row">
          <div class="col-lg-12">
            <button
              class="btn btn-primary"
              type="button"
              style="float:right;"
              @click="guardar"
              :disabled="
                idProyectoSeleccionado === 0 ||
                  listaConfiguracionRolDto.length === 0 ||
                  isListaConfiguracionRolLoading
              "
            >
              <i class="fa fa-save"></i> Guardar
            </button>
          </div>
        </div>
      </div>
    </div>
    <el-dialog
      :visible.sync="agregarRolUsuarioPopUpVisible"
      :show-close="false"
    >
      <agregar-rol-usuario
        v-bind:usuario="nuevoUsuario"
        @cerrarPopUp="cerrarAgregarRolUsuarioPopUp"
        @agregar="agregarRolUsuario"
      />
    </el-dialog>
    <el-dialog
      :visible.sync="disciplinasUsuarioPopUpVisible"
      width="80%"
      :show-close="false"
    >
      <disciplinas-usuario
        v-bind:configuracion="configuracionSeleccionada"
        @cerrarPopUp="cerrarDisciplinasUsuarioPopUp"
      />
    </el-dialog>
  </div>
</template>
<script>
    import AdministracionService from "@/services/administracion.service";
    import SwalAlert from "@/common/swal.alert";
    import { ESTADOS_GENERALES } from "@/constants/maestro.constants";
    import AgregarRolUsuario from "@/components/administracion/gestionRoles/AgregarRolUsuario";
    import DisciplinasUsuario from "@/components/administracion/gestionRoles/DisciplinasUsuario";

    export default {
        name: "Rol",
        data() {
            return {
                idCompaniaSeleccionada: 0,
                idProyectoSeleccionado: 0,
                listaCompanias: [],
                listaProyectos: [],
                listaRoles: [],
                listaDisciplinas: [],
                listaConfiguracionRolDto: [],
                isLoading: false,
                isListaConfiguracionRolLoading: false,
                agregarRolUsuarioPopUpVisible: false,
                disciplinasUsuarioPopUpVisible: false,
                nuevoUsuario: {},
                configuracionSeleccionada: {}
            };
        },
        components: {
            AgregarRolUsuario,
            DisciplinasUsuario
        },
        mounted() {
            this.obtenerCompaniasActivas();
            this.listaProyectos.unshift({
                idProyecto: 0,
                idEstado: ESTADOS_GENERALES.ACTIVO,
                descripcion: ":: SELECCIONE ::"
            });
        },
        methods: {
            obtenerCompaniasActivas() {
                this.isLoading = true;
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
            obtenerProyectosActivos() {
                this.listaProyectos = null;
                this.listaRoles = [];
                this.listaDisciplinas = [];
                this.listaConfiguracionRolDto = [];
                this.isLoading = true;
                AdministracionService.obtenerProyectosPorCompania({
                    idCompania: this.idCompaniaSeleccionada
                })
                    .then(
                        response =>
                        (this.listaProyectos = response.data.listaProyectos.filter(
                            proyecto => proyecto.idEstado === ESTADOS_GENERALES.ACTIVO
                        ))
                    )
                    .then(() =>
                        this.listaProyectos.unshift({
                            idProyecto: 0,
                            idEstado: ESTADOS_GENERALES.ACTIVO,
                            descripcion: ":: SELECCIONE ::"
                        })
                    )
                    .then(
                        () =>
                            (this.idProyectoSeleccionado = this.listaProyectos[0].idProyecto)
                    )
                    .finally(() => (this.isLoading = false));
            },
            abrirAgregarRolUsuarioPopUp() {
                if (this.idProyectoSeleccionado === 0) return;
                this.nuevoUsuario = {
                    idUsuario: 0,
                    nombreUsuario: "",
                    correo: ""
                };
                this.agregarRolUsuarioPopUpVisible = true;
            },
            cerrarAgregarRolUsuarioPopUp() {
                this.agregarRolUsuarioPopUpVisible = false;
            },
            agregarRolUsuario() {
                this.isListaConfiguracionRolLoading = true;
                AdministracionService.obtenerUsuarioPorCorreo({
                    correo: this.nuevoUsuario.correo
                })
                    .then(response => (this.nuevoUsuario = response.data.usuario))
                    .then(() => {
                        if (this.nuevoUsuario.idUsuario === 0) {
                            SwalAlert.error(
                                "No se encontraron usuarios con el correo ingresado."
                            );
                            return;
                        }
                        if (
                            this.listaConfiguracionRolDto.some(
                                x => x.usuarioDto.idUsuario === this.nuevoUsuario.idUsuario
                            )
                        ) {
                            SwalAlert.error(
                                "El usuario ingresado ya ha sido agregado a la lista."
                            );
                            return;
                        }
                        let nuevaConfiguracion = {
                            usuarioDto: {
                                idUsuario: this.nuevoUsuario.idUsuario,
                                nombreUsuario: this.nuevoUsuario.nombreUsuario
                            },
                            listaRolGobernanzaDto: this.listaRoles.map(x => ({ ...x })),
                            listaRolDisciplinaDto: this.listaDisciplinas.map(x => ({ ...x }))
                        };
                        this.listaConfiguracionRolDto = [
                            ...this.listaConfiguracionRolDto,
                            nuevaConfiguracion
                        ];
                        this.cerrarAgregarRolUsuarioPopUp();
                    })
                    .finally(() => (this.isListaConfiguracionRolLoading = false));
            },
            obtenerListaConfiguracionRol() {
                if (this.idProyectoSeleccionado === 0) {
                    this.listaConfiguracionRolDto = [];
                    return;
                }
                this.isListaConfiguracionRolLoading = true;
                AdministracionService.obtenerListaConfiguracionRol({
                    idProyecto: this.idProyectoSeleccionado
                })
                    .then(response => {
                        this.listaRoles = response.data.gestionRolResponse.listaRoles;
                        this.listaDisciplinas =
                            response.data.gestionRolResponse.listaDisciplinas;
                        this.listaConfiguracionRolDto =
                            response.data.gestionRolResponse.listaConfiguracionRolDto;
                    })
                    .finally(() => (this.isListaConfiguracionRolLoading = false));
            },
            verDisciplinas(configuracion) {
                this.configuracionSeleccionada = configuracion;
                this.disciplinasUsuarioPopUpVisible = true;
            },
            cerrarDisciplinasUsuarioPopUp() {
                this.disciplinasUsuarioPopUpVisible = false;
            },
            gestionarCambioDisciplinas(configuracion, rol) {
                if (rol.orden === 1 && rol.idEstado === false) {
                    if (Array.isArray(configuracion.listaRolDisciplinaDto) && configuracion.listaRolDisciplinaDto.length) {
                        configuracion.listaRolDisciplinaDto.forEach(
                            item => { item.idEstado = false; }
                        );
                    }
                }
            },
            guardar() {
                this.$store.commit(`solicitudServicio/SET_LOADING`, true);

                let gestionRolRequest = {
                    listaRoles: this.listaRoles,
                    listaDisciplinas: this.listaDisciplinas,
                    listaConfiguracionRolDto: this.listaConfiguracionRolDto,
                    idProyecto: this.idProyectoSeleccionado
                };

                gestionRolRequest.listaConfiguracionRolDto.map(config => {
                    config.listaRolGobernanzaDto.map(item => {
                        item.idEstado = item.idEstado ? 1 : 0;
                    });
                    config.listaRolDisciplinaDto.map(item => {
                        item.idEstado = item.idEstado ? 1 : 0;
                    });
                });

                AdministracionService.guardarConfiguracionRol(gestionRolRequest).then(
                    response => {
                        this.$store.commit(`solicitudServicio/SET_LOADING`, false);
                        if (response.data.flagError) {
                            SwalAlert.error(response.data.mensaje);
                            return;
                        }
                        SwalAlert.success(response.data.mensaje);
                        this.obtenerListaConfiguracionRol();
                    }
                );
            }
        }
    };
</script>