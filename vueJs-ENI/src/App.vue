<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <header>
    <img alt="Vue logo" class="logo" src="@/assets/emp-icon.png" width="125" height="125" />

    <div class="wrapper">
      <HelloWorld msg="Gestionnaire d'employé"/>

      <nav>
        <!-- <RouterLink to="/home">Accueil</RouterLink> -->
        <!-- <RouterLink to="/about">About</RouterLink> -->
        <RouterLink to="/">Ajout</RouterLink>
        <RouterLink to="/list">Liste</RouterLink>
      </nav>

    </div>
  </header>

  <RouterView />
</template>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:focus {
  background-color: transparent;
  border-width: 0 0 3px 0;
  border-style: solid;
  border-color: springgreen;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  font-size: 18px;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: 20px;
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;
    padding: 1rem 0;
    /* margin-top: 1rem; */
  }
}
</style>
