<template>
  <div>
    <div class="row wrapper border-bottom white-bg page-heading">
      <div class="col-lg-10">
        <h2>Gestión de Roles</h2>
        <ol class="breadcrumb">
          <li>
            <a href>Home</a>
          </li>
          <li>
            <a>Administración</a>
          </li>
          <li class="active">
            <strong>Gestión de Roles</strong>
          </li>
        </ol>
      </div>
    </div>
    <div class="wrapper wrapper-content">
      <rol />
    </div>
  </div>
</template>
<script>
import Rol from "@/components/administracion/gestionRoles/Rol";
export default {
  components: {
    Rol
  }
};
</script>