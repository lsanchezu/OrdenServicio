<template>
  <div>
    <div class="row wrapper border-bottom white-bg page-heading">
      <div class="col-lg-10">
        <h2>Gestión de Gobernanza</h2>
        <ol class="breadcrumb">
          <li>
            <a href>Home</a>
          </li>
          <li>
            <a>Administración</a>
          </li>
          <li class="active">
            <strong>Gestión de Gobernanza</strong>
          </li>
        </ol>
      </div>
    </div>
    <div class="wrapper wrapper-content">
      <gobernanza/>
    </div>
  </div>
</template>
<script>
import Gobernanza from '@/components/administracion/gestionGobernanza/Gobernanza'
export default {
    components:{
        Gobernanza
    }
}
</script>