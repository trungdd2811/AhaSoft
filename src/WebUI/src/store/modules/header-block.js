// import data from '../../api/data'
// demo data
const notices = [
  { 'content': '[25-08-2018] 시스템 공지사항이 등록되었습니다. (단골플러스 사용자 분들께 알려드립니다.)' },
  { 'content': '[26-08-2018] 등록가능한 예약대기자가 있습니다. (2018-08-31 14:00 예약취소)' },
  { 'content': '[27-08-2018] 온라인 예약이 등록되었습니다. (2018.08.31 12:00~14:00)' }
]

const noticesMore = [
  { 'content': '[28-08-2018] 시스템 공지사항이 등록되었습니다. (단골플러스 사용자 분들께 알려드립니다.)' },
  { 'content': '[29-08-2018] 등록가능한 예약대기자가 있습니다. (2018-08-31 14:00 예약취소)' },
  { 'content': '[30-08-2018] 온라인 예약이 등록되었습니다. (2018.08.31 12:00~14:00)' }
]

// initial state
const state = {
  notices
}

// getters
const getters = {
  getNotices: (state) => {
    return state.notices
  }
}

// mutations
const mutations = {
  addNoticesMore: (state) => {
    return state.notices = state.notices.concat(noticesMore)
  },
  deleteNotice: (state, notice) => {
    state.notices.splice(state.notices.indexOf(notice), 1)
  }
}

// actions
const actions = {
  addNoticesToView: ({state,commit}) => {
    commit('addNoticesMore')
  },
  deleteNoticesFromView: ({state,commit}) => {
    commit('deleteNotice')
  }
}

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}
