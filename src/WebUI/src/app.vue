<template>
  <div id="app">
    <header-block/>
    <router-view/>
    <footer-block/>
  </div>
</template>

<script>
import header_block from './components/header-block/header-block.vue'
import footer_block from './components/footer-block/footer-block.vue'

export default {
    components: {
        'header-block': header_block,
        'footer-block': footer_block
    }
}
</script>
