<template>
  <li>
    <h2><slot/></h2>
    <div class="box">
      <dl>
        <dt class="hide"/>
        <dd 
          v-for="row in data.contents" 
          :key="row.index">{{ row.content }}</dd>
      </dl>
    </div>
  </li>
</template>

<script>

export default {
    // eslint-disable-next-line vue/require-prop-types
    props: {
        data: {
            type: Object,
            default: null,
        }
    }
}
</script>

<style lang='scss'>
@import './system-notice.scss';

</style>
