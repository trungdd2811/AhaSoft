import Vue from 'vue'
import VueI18n from 'vue-i18n'

Vue.use(VueI18n)

const i18n = new VueI18n({
    locale: 'en',
    messages: {
        'en': require('./en.json'),
        'kr': require('./kr.json')
    }
})

if (module.hot) {
    module.hot.accept(['./en.json', './kr.json'], () => {
        i18n.setLocaleMessage('en', require('./en.json'))
        i18n.setLocaleMessage('ja', require('./kr.json'))
    })
}

export default i18n
