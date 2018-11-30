// import data from '../../api/data'
// demo data
const sales_today_data = {
    values: [
        { value: '1,500,000' },
        { value: '200,000' },
        { value: '2,000,000' },
        { value: '1,000,000' }
    ],
    total: '4,700,000'
}

const booking_today_data = {
    values: [
        { value: '20' },
        { value: '3' },
        { value: '1' },
        { value: '5' }
    ],
    total: ''
}

const client_today_data = {
    values: [
        { value: '5' },
        { value: '15' },
        { value: '3' }
    ],
    total: '23'
}

const system_notice_data = {
    'title': 'SYSTEM NOTICE',
    'contents': [
        { 'content': 'Notice for server updates.' },
        { 'content': 'New functions added.' },
        { 'content': 'New year holidays 2.' }
    ]
}

const headquater_notice_data = {
    'title': 'HEADQUATER NOTICE',
    'contents': [
        { 'content': 'Notice for server updates.' },
        { 'content': 'New functions added.' },
        { 'content': 'New year holidays 2.' }
    ]
}

const salon_qa_data = {
    'title': 'SALON Q & A',
    'contents': [
        { 'content': 'Notice for server updates.' },
        { 'content': 'New functions added.' },
        { 'content': 'New year holidays 2.' }
    ]
}

// initial state
const state = {
    sales_today_data,
    client_today_data,
    booking_today_data,
    system_notice_data,
    headquater_notice_data,
    salon_qa_data
}

// getters
const getters = {
    getTodaySales: (state) => {
        return state.sales_today_data
    },
    getTodayBooking: (state) => {
        return state.booking_today_data
    },
    getTodayClient: (state) => {
        return state.client_today_data
    },
    getNoticeSystem: (state) => {
        return state.system_notice_data
    },
    getNoticeHeadquater: (state) => {
        return state.headquater_notice_data
    },
    getSalonQA: (state) => {
        return state.salon_qa_data
    }
}

// mutations
const mutations = {

}

// actions
const actions = {

}

export default {
    namespaced: true,
    state,
    getters,
    mutations,
    actions
}
