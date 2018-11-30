<template>
  <li>
    <slot name="head-title"/>
    <div class="box">
      <slot name="sub-title"/>
      <dl class="value">
        <dd 
          v-for="row in data.values" 
          :key="row.index">{{ row.value }}</dd>
      </dl>
      <p 
        v-if="data.total !== ''" 
        class="total">
        <slot name="end-title"/><strong>{{ data.total }}</strong>
      </p>
    </div>
  </li>
</template>

<script>
export default {
    props: {
        data: {
            type: Object,
            default: null,
        }
    }
}
</script>

<style lang='scss'>
@import './sales-today.scss';

</style>
