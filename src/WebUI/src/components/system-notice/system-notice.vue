<template>
  <li>
    <h2><slot></slot></h2>
    <div class="box">
      <dl>
        <dt class="hide"></dt>
        <dd v-for="row in data.contents" :key="row.index">{{ row.content }}</dd>
      </dl>
    </div>
  </li>
</template>

<script>

export default {
    props: ['data']
}
</script>

<style lang='scss'>
@import './system-notice.scss';

</style>
