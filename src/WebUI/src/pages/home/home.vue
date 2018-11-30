<template>
  <main>
    <section 
      id="content" 
      class="index-page">
      <div class="inner">
        <article class="row row-sales">
          <ul class="clearfix">
            <sales-today :data="sales_today_data">
              <h2 slot="head-title">{{ $t('sales-today') }}</h2>
              <dl 
                slot="sub-title" 
                class="sub-title">
                <dd>{{ $t('service') }}</dd>
                <dd>{{ $t('product') }}</dd>
                <dd>{{ $t('prepaid-card') }}</dd>
                <dd>{{ $t('prepaid-service') }}</dd>
              </dl>
              <span slot="end-title">{{ $t('total-sales') }}</span>
            </sales-today>
            <sales-today :data="booking_today_data">
              <h2 slot="head-title">{{ $t('booking-today') }}</h2>
              <dl 
                slot="sub-title" 
                class="sub-title">
                <dd>{{ $t('total') }}</dd>
                <dd>{{ $t('canceles') }}</dd>
                <dd>{{ $t('no-show') }}</dd>
                <dd>{{ $t('upcoming-booking') }}</dd>
              </dl>
              <span slot="end-title">{{ $t('total') }}</span>
            </sales-today>
            <sales-today :data="client_today_data">
              <h2 slot="head-title">{{ $t('client-today') }}</h2>
              <dl 
                slot="sub-title" 
                class="sub-title">
                <dd>{{ $t('new') }}</dd>
                <dd>{{ $t('repeat') }}</dd>
                <dd>{{ $t('walk-in') }}</dd>
              </dl>
              <span slot="end-title">{{ $t('total') }}</span>
            </sales-today>
          </ul>
        </article>

        <article class="row row-info">
          <ul class="clearfix">
            <system-notice :data="system_notice_data">{{ $t('system-notice') }}</system-notice>
            <system-notice :data="headquater_notice_data">{{ $t('headquarter-notice') }}</system-notice>
            <system-notice :data="salon_qa_data">{{ $t('salon-qa') }}</system-notice>
          </ul>
        </article>
      </div>
    </section>
  </main>
</template>

<script>
import sales_today from './../../components/sales-today/sales-today.vue'
import system_notice from './../../components/system-noticestem-notice.vue'
import { mapGetters } from 'vuex'

export default {
    components: {
        'sales-today': sales_today,
        'system-notice': system_notice
    },
    computed: {
        // notice
        ...mapGetters('page_home', {
            sales_today_data: 'getTodaySales',
            booking_today_data: 'getTodayBooking',
            client_today_data: 'getTodayClient',
            system_notice_data: 'getNoticeSystem',
            headquater_notice_data: 'getNoticeHeadquater',
            salon_qa_data: 'getSalonQA'
        })
    }
}
</script>

<style lang='scss' scoped>
@import './home.scss';

</style>