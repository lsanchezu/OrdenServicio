<template>
  <div>
    <div class="row wrapper border-bottom white-bg page-heading">
      <div class="col-lg-10">
        <h2>Gestión de Usuarios</h2>
        <ol class="breadcrumb">
          <li>
            <a href>Home</a>
          </li>
          <li>
            <a>Administración</a>
          </li>
          <li class="active">
            <strong>Gestión de Usuarios</strong>
          </li>
        </ol>
      </div>
    </div>
    <div class="wrapper wrapper-content">
      <usuario />
    </div>
  </div>
</template>
<script>
import Usuario from "@/components/administracion/gestionUsuarios/Usuario";
export default {
  components: {
    Usuario
  }
};
</script>