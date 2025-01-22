<template>
  <div>
    <div class="row wrapper border-bottom white-bg page-heading">
      <div class="col-lg-10">
        <h2>Gestión de Compañías y Proyectos</h2>
        <ol class="breadcrumb">
          <li>
            <a href>Home</a>
          </li>
          <li>
            <a>Administración</a>
          </li>
          <li class="active">
            <strong>Gestión de Compañías y Proyectos</strong>
          </li>
        </ol>
      </div>
    </div>
    <div class="wrapper wrapper-content">
      <el-tabs type="border-card">
        <el-tab-pane label="Compañía / Proyecto">
          <compania/>
        </el-tab-pane>
        <el-tab-pane label="Disciplina">
          <disciplina/>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
</template>

<script>
import Compania from "@/components/administracion/gestionCompaniasProyectos/Compania";
import Disciplina from "@/components/administracion/gestionCompaniasProyectos/Disciplina";

export default {
  components: {
    Compania,
    Disciplina
  }
};
</script>
