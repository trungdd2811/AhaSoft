const webpack = require('webpack')
const path = require('path')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const UglifyJsPlugin = require('uglifyjs-webpack-plugin')
const HtmlWebpackPlugin = require('html-webpack-plugin')
const CopyWebpackPlugin = require('copy-webpack-plugin')
const CleanWebpackPlugin = require('clean-webpack-plugin')
const VueLoaderPlugin = require('vue-loader/lib/plugin')
// const { VueLoaderPlugin } = require('vue-loader')
// const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin
// const DashboardPlugin = require('webpack-dashboard/plugin')

module.exports = {
  mode: 'development',
  entry: './src/app.js',
  output: {
    filename: 'bundle.js',
    publicPath: '/',
    path: path.resolve(__dirname, './dist')    
  },
  devServer: {
    contentBase: './dist',
    hot: true
  },
  devtool: 'source-map',
  performance: {
    hints: false
    // hints: 'warning'
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: 'vue-loader'
      },
      {
        test: /\.(s*)css$/,
        use: [
          'style-loader',
          {
            loader: 'css-loader',
            options: {
              url: false,
              sourceMap: true
            }
          },
          {
            loader: 'sass-loader',
            options: {
              url: false,
              sourceMap: true 
            }
          },
          {
            loader: 'sass-resources-loader',
            options: {
              url: false,
              sourceMap: true,
              resources: './src/template/_variables.scss'
            }
          }
        ]
      },
      {
        test: /\.(png|jpg|gif)$/,
        use: [
          {
            loader: 'file-loader',
            options: {
              name: 'images/[hash].[ext]'
            }
          }
        ]
      }
    ]
  },
  resolve: {
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    },
    extensions: ['*', '.js', '.vue', '.json']
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: '[name].css',
      chunkFilename: '[id].css'
    }),
    new HtmlWebpackPlugin({
      template: './src/index.html'
    }),
    new CopyWebpackPlugin(
      [
        { from: './src/template/', to: './template' }
      ],
      {
        copyUnmodified: false,
        debug: false
      }
    ),
    new CleanWebpackPlugin(['dist']),
    new webpack.HotModuleReplacementPlugin(),
    new VueLoaderPlugin()
    // new BundleAnalyzerPlugin()
    // new DashboardPlugin() // UI command so great
  ],
  optimization: {
    minimizer: [new UglifyJsPlugin({
      cache: false,
      parallel: true
    })],
    // splitChunks: {
    //   chunks: 'all',
    //   cacheGroups: {
    //     // styles: {
    //     //   name: 'styles',
    //     //   test: /\.css$/,
    //     //   chunks: 'all',
    //     //   enforce: true
    //     // },
    //     commons: {
    //       test: /[\\/]node_modules[\\/]/,
    //       name: 'vendors',
    //       chunks: 'all'
    //     }
    //   }
    // }
  }
}
