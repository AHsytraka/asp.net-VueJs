<script>
import axios from 'axios';

</script>

<template>
  <main>
    <div>
        <form id="form-add">
            <label>Nom</label>
            <input type="text"/>
            <label>Salaire</label>
            <input type="text"/>
            <button type="button">Modifier</button>
        </form>
    </div>
</main>
</template>


<style scoped>
     #form-add {
        display: flex;
        flex-direction: column;
     }

     #form-add input{
        width: 50%;
     }

     #form-add button{
        width: 50%;
     }
</style>