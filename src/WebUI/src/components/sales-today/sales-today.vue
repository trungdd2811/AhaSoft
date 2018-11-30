<template>
  <li>
    <slot name="head-title"></slot>
    <div class="box">
      <slot name="sub-title"></slot>
      <dl class="value">
        <dd v-for="row in data.values" :key="row.index">{{ row.value }}</dd>
      </dl>
      <p class="total" v-if="data.total !== ''">
        <slot name="end-title"></slot><strong>{{ data.total }}</strong>
      </p>
    </div>
  </li>
</template>

<script>
export default {
    props: ['data']
}
</script>

<style lang='scss'>
@import './sales-today.scss';

</style>
