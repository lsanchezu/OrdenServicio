import actions from './actions';
import mutations from './mutations';
import { initialState } from './state';

export default {
    namespaced: true,
    state : initialState(),
    actions,
    mutations,
  };