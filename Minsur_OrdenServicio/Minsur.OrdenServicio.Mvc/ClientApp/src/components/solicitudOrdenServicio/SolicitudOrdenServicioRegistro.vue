<template>
    <form>
           <!-- Datos de la Solicitud --->
           <div class="ibox float-e-margins">
               <div class="ibox-title">
                   <h5>Solicitud de Cambio</h5>
               </div>
               <div class="ibox-content m-b-sm border-bottom">
                <div class="row">
                    <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Fecha Solicitud</label>
                               <input type="text" id="status" name="status" v-model="solicitud.fechaSolicitud" class="form-control" readonly>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Denominación del Proveedor</label>
                               <input type="text" id="order_id" name="order_id" v-model="solicitud.usuarioSolicitudDto.nombreApellido" class="form-control" readonly="readonly">
                           </div>
                       </div>
                       <!-- <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Fase del Proyecto</label>
                               <select name="cboFaseProyecto" v-model="solicitud.faseProyectoDto.idFaseProyecto"
                                    v-validate="'select_required'"
                                    :class="{'form-control': true, 'error': errors.has('cboFaseProyecto') }">
                                   <option v-for="item in listaFaseProyecto" v-bind:value="item.idFaseProyecto" :key="item.idFaseProyecto">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboFaseProyecto')">{{ errors.first('cboFaseProyecto') }}</label>
                           </div>
                       </div> -->
                       <!-- <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Área</label>
                               <select name="cboAreaFuncional" v-model="solicitud.areaFuncionalDto.idAreaFuncional"
                                    v-validate="'select_required'"
                                    :class="{'form-control': true, 'error': errors.has('cboAreaFuncional') }">
                                   <option v-for="item in listaAreaFuncional" v-bind:value="item.idAreaFuncional" :key="item.idAreaFuncional">{{ item.descripcion }}</option>
                               </select>
                                <label class="error" v-show="errors.has('cboAreaFuncional')">{{ errors.first('cboAreaFuncional') }}</label>
                           </div>
                       </div> -->
                       
                       <!-- <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Categoría</label>
                               <input type="text" id="order_id" name="order_id" v-model="solicitud.categoriaDto.descripcion" class="form-control" readonly="readonly">
                           </div>
                       </div> -->
                   </div>
                   <div class="row">
    
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Compañía</label>
                               <select name="cboCompania" v-model="solicitud.companiaDto.idCompania" @change="listarProyecto"
                                        v-validate="'select_required'"
                                        :class="{'form-control': true, 'error': errors.has('cboCompania') }">
                                   <option v-for="item in listaCompania" v-bind:value="item.idCompania" :key="item.idCompania">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboCompania')">{{ errors.first('cboCompania') }}</label>
                           </div>
                       </div>
                       
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Proyecto</label>
                               <select name="cboProyecto" v-model="solicitud.proyectoDto.idProyecto"
                                    v-validate="'select_required'"
                                    :class="{'form-control': true, 'error': errors.has('cboProyecto') }">
                                    <option value="0">:: SELECCIONE ::</option>
                                   <option v-for="item in listaProyecto" v-bind:value="item.idProyecto" :key="item.idProyecto">{{ item.descripcion }}</option>
                               </select>
                                <label class="error" v-show="errors.has('cboProyecto')">{{ errors.first('cboProyecto') }}</label>
                           </div>
                       </div>
                       <!-- <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Fuente de Contratación</label>
                               <select name="cboFuenteContrato" v-model="solicitud.fuenteContratoDto.idFuenteContrato"
                                   v-validate="'select_required'"
                                   :class="{'form-control': true, 'error': errors.has('cboFuenteContrato') }">>
                                   <option v-for="item in listaFuenteContrato" v-bind:value="item.idFuenteContrato" :key="item.idFuenteContrato">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboFuenteContrato')">{{ errors.first('cboFuenteContrato') }}</label>
                           </div>
                       </div> -->
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Contratos</label>
                               <select name="cboContratos" v-model="solicitud.contratoDto.idContrato"
                                        v-validate="'select_required'"
                                        :class="{'form-control': true, 'error': errors.has('cboContratos') }">
                                   <option v-for="item in listaContratos" v-bind:value="item.idContrato" :key="item.idContrato">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboContratos')">{{ errors.first('cboContratos') }}</label>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Número de solicitud </label>
                               <input type="number" id="order_id" name="order_id" readonly v-model="nroSolicitud" placeholder="Número de solicitud" class="form-control" maxlength="100" 
                               v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Denominación del Contrato</label>
                               <input type="text" id="order_id" readonly name="order_id" v-model="denominacion" placeholder="Denominación del contrato" class="form-control" maxlength="100" 
                               v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Requerida Por</label>
                               <select name="cboRequerido" v-model="solicitud.requeridoDto.idRequerido"
                                        v-validate="'select_required'"
                                        :class="{'form-control': true, 'error': errors.has('cboRequerido') }">
                                   <option v-for="item in listaRequeridos" v-bind:value="item.idRequerido" :key="item.idRequerido">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboRequerido')">{{ errors.first('cboRequerido') }}</label>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Nombre del Solicitante </label>
                               <input type="text" id="order_id" name="order_id" v-model="nombreEmpresa" placeholder="Nombre del solicitante" class="form-control" maxlength="100" 
                               v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div>
                       <!-- <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Número de solicitud </label>
                               <input type="number" id="order_id" name="order_id" readonly v-model="nroSolicitud" placeholder="Número de solicitud" class="form-control" maxlength="100" 
                               v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div> -->
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Monto de la solicitud de cambio</label>
                               <vue-numeric name="txtMontoEstimado" separator="," v-model="solicitud.montoEstimado" v-bind:precision="2"
                                   placeholder="Ingresar monto" onkeypress="return validar_Numero_Punto(event)" maxlength="18"
                                   
                                   :class="{'form-control': true, 'error': errors.has('txtMontoEstimado') }"
                               ></vue-numeric>
                               <label class="error" v-show="errors.has('txtMontoEstimado')">{{ errors.first('txtMontoEstimado') }}</label>
                           </div>
                       </div>

                       <div class="col-sm-4">
                        <div class="form-group">
                               <label class="control-label" for="plazp">Plazo estimado del cambio </label>
                               <input type="date" id="plazo" name="plazo" v-model="plazo" placeholder="Plazo estimado del cambio" class="form-control" maxlength="100" 
                               >
                        </div>
                       </div>
                       <div class="col-sm-4">
                        <div class="form-group">
                            <label for="impactoMonto">¿Impacto en el monto?</label>
                            <select v-model="impactoMonto" class="form-control" id="impactoMonto" @change="toggleMonto">
                            <option value="no">No</option>
                            <option value="si">Sí</option>
                            </select>
                        </div>

                        <div v-if="impactoMonto === 'si'" class="form-group">
                            <label for="monto">Monto:</label>
                            <input type="number" class="form-control" id="monto" v-model="monto" placeholder="Ingrese el monto" />
                        </div>
                       </div>
                       <div class="col-sm-5">
                        <div class="form-group">
                            <label for="impactoPlazo">¿Impacto en el plazo?</label>
                            <select v-model="impactoPlazo" class="form-control" id="impactoPlazo" @change="togglePlazo">
                            <option value="no">No</option>
                            <option value="si">Sí</option>
                            </select>
                        </div>

                            <div v-if="impactoPlazo === 'si'" class="form-group">
                                <label for="plazoEstimado">Plazo estimado de cambio (días):</label>
                                <input type="number" class="form-control" id="plazoEstimado" v-model="plazoEstimado" placeholder="Ingrese el plazo estimado" />
                            </div>

                            <div v-if="impactoPlazo === 'si'" class="form-group">
                                <label for="fechaInicio">Fecha de inicio:</label>
                                <input type="date" class="form-control" id="fechaInicio" v-model="fechaInicio" />
                            </div>

                            <!-- <div v-if="impactoPlazo === 'si'" class="form-group">
                                <label for="fechaFin">Fecha de fin:</label>
                                <input type="date" class="form-control" id="fechaFin" v-model="fechaFin" />
                            </div> -->
                       </div>
                       <!-- <div class="col-sm-4">
                            <div>
                                <label class="control-label" for="customer">Impacto</label>
                                <br>
                                <label v-for="fruit in fruits" :key="fruit">
                                <input
                                    type="checkbox"
                                    :value="fruit"
                                    v-model="selectedFruits"
                                />
                                {{ fruit }}
                                </label>
                            </div>
                       </div> -->
                       <div class="col-sm-12">
                           <div class="form-group">
                               <label class="control-label" for="txtDenominacionServicio">Detalle de la solicitud</label> 
                               <textarea name="txtDenominacionServicio"  
                                       rows="3" maxlength="1024" 
                                       v-model="solicitud.denominacionServicio" 
                                       placeholder="Ingrese del detalle(cant. max. 1024)" 
                                       spellcheck="true" onkeypress="return val_DescripcionQ(event)" 
                                       v-validate="'required'"
                                       :class="{'form-control': true, 'error': errors.has('txtDenominacionServicio') }"
                                       >
                                </textarea>
                                <label class="error" v-show="errors.has('txtDenominacionServicio')">{{ errors.first('txtDenominacionServicio') }}</label>
                           </div>
                       </div>
                   </div>
                   
                   <!-- <div class="row">
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Fecha Solicitud</label>
                               <input type="text" id="status" name="status" v-model="solicitud.fechaSolicitud" class="form-control" readonly>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Categoría</label>
                               <input type="text" id="order_id" name="order_id" v-model="solicitud.categoriaDto.descripcion" class="form-control" readonly="readonly">
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Tipo</label>
                                <select name="cboTipo" v-model="solicitud.tipoDto.idTipo"
                                    v-validate="'select_required'"
                                    :class="{'form-control': true, 'error': errors.has('cboTipo') }">
                                   <option v-for="item in listaTipo" v-bind:value="item.idTipo" :key="item.idTipo">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboTipo')">{{ errors.first('cboTipo') }}</label>                                                              
                           </div>
                       </div>
                   </div> -->
               </div>
           </div>
           <!-- Alcance del Servicio a Contratar  --->
           <!-- <div class="ibox float-e-margins">
                <div class="ibox-title">
                   <h5>Alcance del Servicio a Contratar</h5>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Moneda</label>
                               <select name="cboMoneda" v-model="solicitud.monedaDto.idMoneda"
                                   v-validate="'select_required'"
                                   :class="{'form-control': true, 'error': errors.has('cboMoneda') }">
                                   <option v-for="item in listaMoneda" v-bind:value="item.idMoneda" :key="item.idMoneda">{{ item.descripcion }}</option>
                               </select>
                               <label class="error" v-show="errors.has('cboMoneda')">{{ errors.first('cboMoneda') }}</label>
                           </div>
                       </div>
                       <div class="col-sm-4" v-if="solicitud.monedaDto.idMoneda == OtraMoneda">
                           <div class="form-group">
                               <label class="control-label" for="status">Descripción Moneda</label>
                               <input type="text" name="txtOtraMoneda" 
                               v-model="solicitud.descripcionMoneda" 
                               class="form-control" 
                                maxlength="50"
                               
                                v-validate="solicitud.monedaDto.idMoneda == OtraMoneda ? 'required' : '' " 
                                :class="{'form-control': true, 'error': errors.has('txtOtraMoneda') }"
                               >
                               <label class="error" v-show="errors.has('txtOtraMoneda')">{{ errors.first('txtOtraMoneda') }}</label>
    
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Monto Estimado</label>
                               <vue-numeric name="txtMontoEstimado" separator="," v-model="solicitud.montoEstimado" v-bind:precision="2"
                                   placeholder="Ingresar monto" onkeypress="return validar_Numero_Punto(event)" maxlength="18"
                                   v-validate="'text_required'"
                                   :class="{'form-control': true, 'error': errors.has('txtMontoEstimado') }"
                               ></vue-numeric>
                               <label class="error" v-show="errors.has('txtMontoEstimado')">{{ errors.first('txtMontoEstimado') }}</label>
                           </div>
                       </div>
                   </div>
                   <div class="row">
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Fecha Inicio</label>
                               <el-date-picker v-model="solicitud.fechaInicio" 
                                               type="date" format="dd/MM/yyyy" value-format="dd/MM/yyyy" 
                                               placeholder="Seleccione fecha" @change="handleRangoFecha()"
                                               >
                               </el-date-picker>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Fecha Término</label>
                               <el-date-picker v-model="solicitud.fechaTermino" 
                                               type="date" format="dd/MM/yyyy" value-format="dd/MM/yyyy" 
                                               placeholder="Seleccione fecha" @change="handleRangoFecha()">
                              </el-date-picker>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Días Calendario</label>
                               <input type="text" name="customer" v-model="solicitud.diasCalendario" class="form-control" readonly>
                           </div>
                       </div>
                   </div>
               </div>
           </div> -->
           <!-- Descripción del Servicio --->
           <!-- <div class="ibox float-e-margins">
                <div class="ibox-title">
                   <h5>Descripción del Servicio</h5>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <div class="col-sm-12">
                           <div class="form-group">
                               <label class="control-label" for="txtDenominacionServicio">Denominación del Servicio</label> 
                               <textarea name="txtDenominacionServicio"  
                                       rows="3" maxlength="1024" 
                                       v-model="solicitud.denominacionServicio" 
                                       placeholder="Ingrese la denominación del servicio (cant. max. 1024)" 
                                       spellcheck="true" onkeypress="return val_DescripcionQ(event)" 
                                       v-validate="'required'"
                                       :class="{'form-control': true, 'error': errors.has('txtDenominacionServicio') }"
                                       >
                                </textarea>
                                <label class="error" v-show="errors.has('txtDenominacionServicio')">{{ errors.first('txtDenominacionServicio') }}</label>
                           </div>
                       </div>
                       <div class="col-sm-12">
                           <div class="form-group">
                               <label class="control-label" for="txtDescripcionServicio">Descripción del Servicio</label> 
                               <textarea  name = "txtDescripcionServicio" 
                                           rows="3" maxlength="1024" v-model="solicitud.descripcionServicio" 
                                           placeholder="Ingrese la descripción del servicio  (cant. max. 1024)" 
                                           spellcheck="true" onkeypress="return val_DescripcionQ(event)" 
                                           v-validate="'required'"
                                           :class="{'form-control': true, 'error': errors.has('txtDescripcionServicio') }">
                               </textarea>
                               <label class="error" v-show="errors.has('txtDescripcionServicio')">{{ errors.first('txtDescripcionServicio') }}</label>            
                           </div>
                       </div>
                       <div class="col-sm-12">
                           <div class="form-group">
                               <label class="control-label" for="txtUbicacionServicio">Lugar de Ejecución</label>
                               <textarea   name="txtUbicacionServicio" 
                                           rows="3" maxlength="1024" v-model="solicitud.ubicacionServicio" 
                                           placeholder="Ingrese el lugar de ejecución   (cant. max. 1024)" spellcheck="true" onkeypress="return val_DescripcionQ(event)"
                                           v-validate="'required'"
                                           :class="{'form-control': true, 'error': errors.has('txtUbicacionServicio') }" >
                               </textarea>
                               <label class="error" v-show="errors.has('txtUbicacionServicio')">{{ errors.first('txtUbicacionServicio') }}</label>
                           </div>
                       </div>
                      
                   </div>
               </div>
           </div> -->
           <!-- Proveedor/Contratista sugerido --->
           <!-- <div class="ibox float-e-margins">
                <div class="ibox-title">
                   <h5>Proveedor/Contratista Sugerido</h5>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <div class="col-sm-3">
                           <div class="form-group">
                               <label class="control-label" for="order_id">&nbsp;</label>
                               <el-radio-group v-model="Pais" style="width:100%" @change="seleccionarPais()">
                                   <el-radio-button v-for="item in listaPais" :label="item.idPais" :key="item.idPais"> {{ item.descripcion}}</el-radio-button>
                               </el-radio-group>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Denominación Social</label>
                               <input type="text" id="order_id" name="order_id" v-model="nombreEmpresa" placeholder="Ingresar contenido" class="form-control" maxlength="100" 
                               v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div>
                       <div class="col-sm-2">
                           <div class="form-group">
                               <label class="control-label" for="status">RUC</label>
                               <input type="text" id="status" name="status" v-model="rucEmpresa" placeholder="Ingresar contenido" class="form-control" 
                               onkeypress="return validarSoloNumeros(event)" maxlength="11" :disabled="activarRucEmpresa" v-on:keyup.enter="agregarProveedorContratista()">
                           </div>
                       </div> 
                       <div class="col-sm-2">

                           <div class="form-group">
                               <label class="control-label" style="display:block;" for="status">&nbsp;</label>
                               <button class="btn btn-primary" type="button" title="Agregar Proveedor/Contratista" @click="agregarProveedorContratista()"> <i class="fa fa-plus-square"></i>&nbsp; Agregar Proveedor</button>
                           </div>

                           
                       </div>           
                   </div>
                   <div class="row">
                       <div class="col-sm-12">
                           <div class="table-responsive m-t">
                               <table class="table table-striped">
                                   <thead>
                                       <tr>
                                           <th>ITEM</th>
                                           <th>NOMBRE</th>
                                           <th width="25%">RUC</th>
                                           <th width="5%">Eliminar</th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <tr v-for="(item, index) in solicitud.listaSolicitudProveedorContratistaDto" :key="index">
                                           <td>{{index + 1}}</td>
                                           <td>{{item.denominacionSocial}}</td>
                                           <td>{{item.documento}}</td>
                                           <td>
                                               <button class="btn btn-danger" type="button" title="Eliminar Proveedor/Contratista" @click="eliminarProveedorContratista(item)">
                                                   <i class="fa fa-window-close"></i>
                                                </button>
                                           </td>
                                       </tr>
                                   </tbody>
                               </table>
                           </div>
                       </div>
                   </div>
               </div>
           </div> -->
           <!-- Documentos Adjuntos --->
           <div class="ibox float-e-margins">
                <div class="ibox-title">
                   <h5>Documentos Adjuntos</h5>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <documento-adjunto v-for="(documento, index) in listaDocumento" :key="index" 
                                           :documento= documento 
                                           @agregarArchivo="agregarArchivo"
                                           @eliminarArchivo="eliminarArchivo"
                                           ></documento-adjunto>
                   </div>
               </div>
           </div>
           <!-- SOLE SOURCE:  Justificación de eleción del proveedor --->
           <div class="ibox float-e-margins" v-if="solicitud.fuenteContratoDto.idFuenteContrato === fuenteSoleSource">
                <div class="ibox-title">
                   <h5>SOLE SOURCE: Justificación de elección del proveedor</h5>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <div class="col-sm-12">
                           <textarea class="form-control" 
                               name = "txtJustificacionSoleSource"
                               onkeypress="return val_DescripcionQ(event)"
                               rows="6"
                               maxlength="1024" 
                               v-model="solicitud.justificacionSoleSource"
                               placeholder="Ingrese la justificación (cant. max. 1024)" 
                               spellcheck="true"
                                v-validate="solicitud.fuenteContratoDto.idFuenteContrato === fuenteSoleSource ? 'required' : '' " 
                                :class="{'form-control': true, 'error': errors.has('txtJustificacionSoleSource') }"
                               ></textarea>
                               <label class="error" v-show="errors.has('txtJustificacionSoleSource')">{{ errors.first('txtJustificacionSoleSource') }}</label>
                       </div>
                   </div>    
               </div>
           </div>
           <div class="ibox float-e-margins" v-if="false">
                <div class="ibox-title">
                   <h5>RECOMENDACIÓN ENCARGADO DE PROCURA Y CONTRATOS</h5>
                   <div class="ibox-tools">
                       <a class="collapse-link">
                           <i class="fa fa-chevron-up"></i>
                       </a>
                   </div>
               </div>
               <div class="ibox-content">
                   <div class="row">
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="order_id">Nombre</label>
                               <input type="text" name="status" v-model="solicitud.recomendacionProduraContrato.nombre" class="form-control" readonly> 
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="status">Firma</label>
                               <input type="text" id="status" name="status" class="form-control" readonly>
                           </div>
                       </div>
                       <div class="col-sm-4">
                           <div class="form-group">
                               <label class="control-label" for="customer">Fecha</label>
                                <input type="text" name="status" v-model="solicitud.recomendacionProduraContrato.fecha" class="form-control" readonly> 
                           </div>
                       </div>
                   </div>
                   <div class="row">
                       <div class="col-sm-12">
                           <textarea class="form-control" 
                                   onkeypress="return val_DescripcionQ(event)"
                                   rows="6"
                                   maxlength="500" 
                                   v-model="solicitud.recomendacionProduraContrato.comentario"
                                   spellcheck="true"></textarea>
                       </div>                
                   </div>
               </div>
           </div>
           <div class="row" >
               <div class="col-sm-12">
                    <button class="btn btn-primary m-b-md" type="button" @click="validarRegistroSolicitud" style="float:right;"><i class="fa fa-save"></i> Registrar Solicitud</button>
               </div>
           </div>
   </form>
</template>
<script>

   import VueNumeric from 'vue-numeric'
   import MaestroService from '@/services/maestro.service'
   import SolicitudService from '@/services/solicitud.service'
   import DocumentoAdjunto from '@/components/solicitudOrdenServicio/DocumentoAdjunto'
   import { PESO_MAXIMO_REGISTRO_ARCHIVO, MB_TO_BYTES } from '@/constants/solicitud.constants'
   import {
       PAIS_PERU,
       OTRA_MONEDA,
       FUENTE_CONTRATO_PRERENTE,
       FUENTE_CONTRATO_SOLE_SOURCE,
       TIPO_DOCUMENTO_ALCANCE_TRABAJO,
   } from '@/constants/solicitud.constants'

   import { createNamespacedHelpers } from 'vuex'
   const { mapState } = createNamespacedHelpers('auth')
   import SwalAlert from '@/common/swal.alert'
   import obj2fd from 'obj2fd'

   export default {
       name: "solicitud-orden-servicio-registro",
       components: {
           VueNumeric,
           DocumentoAdjunto
       },
       props: {
           solicitudSelected: { type: Object, required: false, default: null }
       },
       data() {
           return {
               OtraMoneda: OTRA_MONEDA,
               Pais: PAIS_PERU,
               fuentePreferente: FUENTE_CONTRATO_PRERENTE,
               fuenteSoleSource: FUENTE_CONTRATO_SOLE_SOURCE,
               listaFuenteContrato: [],
               listaProyecto: [],
               listaCompania: [],
               listaFaseProyecto: [],
               listaMoneda: [],
               listaAreaFuncional: [],
               listaPais: [],
               listaTipo: [],
               listaRequeridos: [{idRequerido: 0, descripcion: '::SELECCIONE::'},{idRequerido: 2, descripcion: 'CLIENTE'}, {id: 3, descripcion: 'PROVEEDOR'}],
               nombreEmpresa: "",
               nroSolicitud: "1",
               rucEmpresa: "",
               denominacion: "Contrato 1",
               solicitud: {},
               listaDocumentoAdjunto: [],
               listaDocumento: [{tipoDocumento: {
                idTipoDocumento: 1,
                descripcion: 'Propuesta'
                },
                listaArchivo: []},{tipoDocumento: {
                idTipoDocumento: 2,
                descripcion: 'Detalle económico'
                },
                listaArchivo: []},
                {tipoDocumento: {
                idTipoDocumento: 3,
                descripcion: 'Planos'
                },
                listaArchivo: []},
                {tipoDocumento: {
                idTipoDocumento: 4,
                descripcion: 'Cronograma'
                },
                listaArchivo: []}],
               fruits: ['IMPACTO - EFECTO EN EL ALCANCE', 'IMPACTO - EFECTO EN EL MONTO DE CONTRATO', 'IMPACTO - EFECTO EN EL CRONOGRAMA CONTRACTUAL'], // Lista de frutas
               selectedFruits: [],
               listaContratos: [{idContrato: 0, descripcion: '::SELECCIONE::'},{idContrato: 2, descripcion: 'CONTRATO 1'}],
               initialSolicitud: {
                   tipoDto: { idTipo: 0 },
                   companiaDto: { idCompania: 0 },
                   contratoDto: {idContrato: 0},
                   requeridoDto: {idRequerido: 0},
                   fuenteContratoDto: { idFuenteContrato: 0 },
                   proyectoDto: { idProyecto: 0 },
                   faseProyectoDto: { idFaseProyecto: 0 },
                   usuarioSolicitudDto: { nombreApellido: "" },
                   categoriaDto: { descripcion: "" },
                   areaFuncionalDto: { idAreaFuncional: 0 },
                   listaSolicitudDocumentoDto: [],
                   monedaDto: { idMoneda: 0 },
                   paisDto: { idPais: 0 },
                   fechaSolicitud: "",
                   montoEstimado: 0.00,
                   fechaInicio: "",
                   fechaTermino: "",
                   diasCalendario: "",
                   plazo: ""
               },
               totalArchivoCargado: 0,
               plazo: "",
               impactoMonto: 'no', // Valor por defecto
                monto: null,
                impactoPlazo: 'no', // Valor por defecto
                plazoEstimado: null,
                fechaInicio: '',
                fechaFin: '',
                submitted: false,
           }
       },
       computed: {
           ...mapState({
               nombreApellido: state => state.nombreApellido + ' - '+' 78452545652',
               rol: state => state.rol
           }),
           activarRucEmpresa() {
               return (this.Pais !== PAIS_PERU)
           },
           esRequeridoOtraMoneda() {
               return this.solicitud.monedaDto.idMoneda == OtraMoneda ? 'required' : '';
           }
       },
       created() {
           this.solicitud = Object.assign({}, this.initialSolicitud);
       },
       mounted() {
           if (this.solicitudSelected !== null) {
               this.solicitud = this.solicitudSelected;
               return;
           }
           this.$store.commit(`solicitudServicio/SET_LOADING`, true);

           this.inicializar();
       },
       methods: {
           inicializar() {
               var self = this
               this.listaDocumentoAdjunto = []
               MaestroService.obtenerMaestroSolicitud().then(response => {
                   self.inicializarMaestro(response.data);
                   SolicitudService.obtenerNuevaSolicitud().then(response => {
                       self.inicializarReporte(response.data)
                       self.$store.commit(`solicitudServicio/SET_LOADING`, false);
                       self.errors.clear();
                   });

               });
           },
           inicializarMaestro(data) {
               this.listaFuenteContrato = data.maestro.listaFuenteContratoDto
               this.listaProyecto = data.maestro.listaProyectoDto
               this.listaCompania = data.maestro.listaCompaniaDto
               this.listaFaseProyecto = data.maestro.listaFaseProyectoDto
               this.listaMoneda = data.maestro.listaMonedaDto,
               this.listaAreaFuncional = data.maestro.listaAreaFuncionalDto
               this.listaPais = data.maestro.listaPaisDto
               this.listaTipo = data.maestro.listaTipoDto
           },
           inicializarReporte(data) {
                data.solicitudOrdenServicio.contratoDto = {idContrato: 0}
                data.solicitudOrdenServicio.requeridoDto = {idRequerido: 0}
                data.solicitudOrdenServicio.usuarioSolicitudDto = {nombreApellido: data.solicitudOrdenServicio.usuarioSolicitudDto.nombreApellido + ' - '+'10785456123'}
               this.solicitud = data.solicitudOrdenServicio

               this.solicitud.listaSolicitudDocumentoDto.forEach(item => {
                   this.listaDocumentoAdjunto.push({
                       tipoDocumento: item.tipoDocumentoDto,
                       listaArchivo: []
                   })
               });

               this.handleRangoFecha();
           },
           listarProyecto() {
               var self = this
               if (self.solicitud.companiaDto.idCompania == 0) {
                   self.listaProyecto = self.listaProyecto.filter(x => x.idProyecto == 0);
                   self.solicitud.proyectoDto.idProyecto = 0
                   return;
               }

               self.$store.commit(`solicitudServicio/SET_LOADING`, true);
               self.solicitud.proyectoDto.idProyecto = 0;

               var filtroCompania = {
                   idCompania: self.solicitud.companiaDto.idCompania
               };

               MaestroService.listarProyectoPorUsuario(filtroCompania).then(response => {
                   self.listaProyecto = response.data.listaProyecto
               }).finally(() => this.$store.commit(`solicitudServicio/SET_LOADING`, false));
           },
           handleRangoFecha() {
               this.calcularDiasCalendario();
               this.asignarCategoria();
           },
           calcularDiasCalendario() {
               if (isBlank(this.solicitud.fechaInicio) || isBlank(this.solicitud.fechaTermino)) {
                   return "";
               }

               if (CompararFechas(this.solicitud.fechaTermino, this.solicitud.fechaInicio) < 0) {
                   this.solicitud.fechaTermino = "";
                   swal("Mensaje", "La fecha fin debe ser mayor a la fecha inicio.", "warning");
                   return "";
               }

               let f1 = this.solicitud.fechaInicio.split("/")
               let f2 = this.solicitud.fechaTermino.split("/")

               var fechaInicio = new Date(f1[2], f1[1] - 1, f1[0]).getTime();
               var fechaFin = new Date(f2[2], f2[1] - 1, f2[0]).getTime();

               var diff = fechaFin - fechaInicio;

               this.solicitud.diasCalendario = diff / (1000 * 60 * 60 * 24) + 1;

           },
           asignarCategoria() {
               if (isBlank(this.solicitud.fechaInicio)) {
                   this.solicitud.categoriaDto = {
                       idCategoria: 0,
                       descripcion: ""
                   }
                   return;
               }

               let diferencia = CompararFechas(this.solicitud.fechaInicio, this.solicitud.fechaSolicitud)

               if (diferencia >= 0) {
                   this.solicitud.categoriaDto = {
                       idCategoria: 1,
                       descripcion: "NORMAL"
                   }
               }
               else {
                   this.solicitud.categoriaDto = {
                       idCategoria: 2,
                       descripcion: "REGULARIZACIÓN"
                   }
               }
           },
           seleccionarPais() {
               if (this.Pais != PAIS_PERU) {
                   this.rucEmpresa = "";
               }
           },
           agregarProveedorContratista() {
               var self = this;

               if (isBlank(this.nombreEmpresa)) {
                   swal("Mensaje", "Debe ingresar la denominación del proveedor o contratista.", "warning");
                   return;
               }

               if (this.Pais === PAIS_PERU && isBlank(this.rucEmpresa)) {
                   swal("Mensaje", "Debe ingresar el RUC del proveedor o contratista.", "warning");
                   return;
               }

               if (this.Pais === PAIS_PERU && this.rucEmpresa.length != 11) {
                   swal("Mensaje", "El número de RUC debe tener 11 dígitos.", "warning");
                   return;
               }

               if (this.Pais === PAIS_PERU && this.solicitud.listaSolicitudProveedorContratistaDto.find(x => x.documento == self.rucEmpresa) !== undefined) {

                   swal("Mensaje", "El ruc del proveedor o contratista ya se encuentra agregado.", "warning");
                   return;
               }

               if (this.solicitud.listaSolicitudProveedorContratistaDto.find(x => x.denominacionSocial == self.nombreEmpresa) !== undefined) {

                   swal("Mensaje", "El proveedor o contratista ya se encuentra agregado.", "warning");
                   return;
               }

               if (this.validarEsFuenteContratoUnicoProveedor() && this.solicitud.listaSolicitudProveedorContratistaDto.length >= 1) {
                   swal("Mensaje", `La fuente de contratación  ${this.obtenerDescricionFuenteContrato()} solo permite registrar un proveedor o contratista.`, "warning");
                   return;
               }

               this.solicitud.listaSolicitudProveedorContratistaDto.push({
                   paisDto: {
                       idPais: this.Pais
                   },
                   denominacionSocial: this.nombreEmpresa,
                   documento: this.rucEmpresa
               })

               this.nombreEmpresa = "";
               this.rucEmpresa = "";
               this.Pais = PAIS_PERU;
           },
           obtenerDescricionFuenteContrato() {
               return this.listaFuenteContrato.find(x => x.idFuenteContrato === this.solicitud.fuenteContratoDto.idFuenteContrato).descripcion;
           },
           eliminarProveedorContratista(item) {
               this.solicitud.listaSolicitudProveedorContratistaDto = this.solicitud.listaSolicitudProveedorContratistaDto.filter(x => x !== item);
           },
           agregarArchivo(idtipoDocumento, archivo) {

               var total = 0
               this.listaDocumentoAdjunto.forEach(item => {
                   if (item.listaArchivo.length > 0) {
                       total += item.listaArchivo.reduce((a, b) => {
                           return a + b.data.size
                       },
                           0)
                   }
               });

               total += archivo.data.size

               if (total > (PESO_MAXIMO_REGISTRO_ARCHIVO * MB_TO_BYTES)) {
                   SwalAlert.warning(`Superó tamaño maximo del total de archivos para el registro(${PESO_MAXIMO_REGISTRO_ARCHIVO}MB)`)
                   return
               }

               let documentoAdjunto = this.listaDocumentoAdjunto.find(x => x.tipoDocumento.idTipoDocumento == idtipoDocumento);

               if (documentoAdjunto.listaArchivo.find(x => x.nombre == archivo.nombre) != undefined) {
                   SwalAlert.warning("El nombre del archivo ya se encuentra agregado.")
                   return;
               }

               documentoAdjunto.listaArchivo.push(archivo);

               this.totalArchivoCargado = total / MB_TO_BYTES
           },

           eliminarArchivo(idtipoDocumento, id) {
               let documentoAdjunto = this.listaDocumentoAdjunto.find(x => x.tipoDocumento.idTipoDocumento == idtipoDocumento);

               documentoAdjunto.listaArchivo = documentoAdjunto.listaArchivo.filter(x => x.id != id);
               var id = 1
               documentoAdjunto.listaArchivo.forEach(x => {
                   x.id = id;
                   id += 1;
               });
           },
           validarRegistroSolicitud() {
            var self = this
            SwalAlert.successAction('Registrado con éxito', function(){
                           self.$router.push({ name: 'solicitudes' })
                       });
            //    var self = this
            //    this.$validator.validateAll().then((result) => {
            //        if (!result) {
            //            SwalAlert.warning("Debe ingresar los datos obligatorios.")
            //            return;
            //        }


            //        if (!self.validarProveedorPorFuenteContrato()) { return }
            //        if (!self.validarDocumentoAdjunto()) { return }

            //        self.confirmacionRegistroSolicitud();
            //    });
           },
           validarProveedorPorFuenteContrato() {

               if (this.validarEsFuenteContratoUnicoProveedor() && this.solicitud.listaSolicitudProveedorContratistaDto.length !== 1) {
                   swal("Mensaje", `La fuente de contrartación  ${this.obtenerDescricionFuenteContrato()} solo permite registrar una empresa.`, "warning");
                   return false;
               }

               return true;
           },
           validarEsFuenteContratoUnicoProveedor() {
               return (this.solicitud.fuenteContratoDto.idFuenteContrato === FUENTE_CONTRATO_PRERENTE || this.solicitud.fuenteContratoDto.idFuenteContrato === FUENTE_CONTRATO_SOLE_SOURCE)
           },
           validarDocumentoAdjunto() {
               if (isBlank(this.solicitud.fechaInicio) || isBlank(this.solicitud.fechaTermino)) {
                   SwalAlert.warning("Debe ingresar la fecha de inicio y fecha fin.")
                   return false;
               }

               if (this.solicitud.listaSolicitudProveedorContratistaDto.length === 0) {
                   SwalAlert.warning("Debe agregar al menos un proveedor o contratista.")
                   return false;
               }

               let documentoAdjunto = this.listaDocumentoAdjunto.find(x => x.tipoDocumento.idTipoDocumento == TIPO_DOCUMENTO_ALCANCE_TRABAJO);

               if (documentoAdjunto.listaArchivo.length === 0) {
                   SwalAlert.warning("Debe agregar al menos un archivo al campo Alcance de Trabajo.")
                   return false;
               }

               return true;
           },
           confirmacionRegistroSolicitud() {
               SwalAlert.confirmAjax("¿Está seguro(a) de registrar la solicitud de contratación?", this.registrarSolicitud);
           },
           obtenerSolicitudRequest() {
               let solicitudRequest = {
                   SolicitudOrdenServicio: JSON.parse(JSON.stringify(this.solicitud))
               };

               const montoEstimadoFormateado = solicitudRequest.SolicitudOrdenServicio.montoEstimado.toString().replace('.', ',');
               solicitudRequest.SolicitudOrdenServicio.montoEstimado = montoEstimadoFormateado;

               let formData = obj2fd(solicitudRequest);
               this.listaDocumentoAdjunto.forEach((item, index) => {
                   item.listaArchivo.forEach(file => {
                       formData.append(`ListaArchivo_TipoDocumento_${item.tipoDocumento.idTipoDocumento}`, file.data);
                   })
               });

               return formData;
           },
           registrarSolicitud() {
               var self = this
               this.$store.commit(`ordenServicio/SET_LOADING`, true);
               const formData = this.obtenerSolicitudRequest();
               SolicitudService.registrarSolicitud(formData).then(response => {
                   self.$store.commit(`ordenServicio/SET_LOADING`, false);

                   if(response.data.flagError){
                       swal("Mensaje", response.data.mensaje, "warning");
                   }
                   else
                   {
                       SwalAlert.successAction(response.data.mensaje, function(){
                           self.$router.push({ name: 'consulta-orden' })
                       });
                   }
               })
           },
           toggleMonto() {
      if (this.impactoMonto === 'no') {
        this.monto = null; // Limpiar el monto si se selecciona "No"
      }
    },
    togglePlazo() {
      if (this.impactoPlazo === 'no') {
        this.plazoEstimado = null; // Limpiar el plazo si se selecciona "No"
        this.fechaInicio = ''; // Limpiar la fecha de inicio
        this.fechaFin = ''; // Limpiar la fecha de fin
      }
    },
       }
   }
</script>
