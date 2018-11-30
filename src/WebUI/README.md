# ahasoft-admincp

## Project setup
```
npm install
```

## Run eslint to verify all files
```
./node_modules/.bin/eslint  --ext .js,.vue src
```

### Compiles and hot-reloads for development
```
npm run dev
```

### Compiles and minifies for production
```
npm run prod
```

### Project folder structure
```
src/
  components: vue component
  pages: vue pages loaded by router
  router: routers for frond-end
  store: store data & action for ui base vuex
  template: css, js, images, scss for static template
  translate: content for multi language
```

### Make component process
```
1. create new-component.vue
2. create store/module for UI: state, getter, mutation, action
3. add to Pages / Parent Component
  - import new-component.vue into, then registry & add tag
  - getdata from Getter in store
4. translate static title / label
```