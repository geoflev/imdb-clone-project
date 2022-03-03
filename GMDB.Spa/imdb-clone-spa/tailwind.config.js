const defaultTheme = require('tailwindcss/defaultTheme')

module.exports = {
  important: true,
  purge: {
    enabled: false,
    content: ['./src/**/*.{html,ts}']
  },
  theme: {
    colors: {
      'white': '#fff',
      'red-50': '#ffebee',
      'red-100': '#ffcdd2',
      'red-200': '#ef9a9a',
      'red-300': '#e57373',
      'red-400': '#ef5350',
      'red-500': '#f44336',
      'red-600': '#e53935',
      'red-700': '#d32f2f',
      'red-800': '#c62828',
      'red-900': '#b71c1c',
      'red-A100': '#ff8a80',
      'red-A200': '#ff5252',
      'red-A400': '#ff1744',
      'red-A700': '#d50000',
      'gray-50': '#fafafa',
      'gray-100': '#f5f5f5',
      'gray-200': '#eeeeee',
      'gray-300': '#e0e0e0',
      'gray-400': '#bdbdbd',
      'gray-500': '#9e9e9e',
      'gray-600': '#757575',
      'gray-700': '#616161',
      'gray-800': '#424242',
      'gray-900': '#212121',
      'gray-A100': '#ffffff',
      'gray-A200': '#eeeeee',
      'gray-A400': '#bdbdbd',
      'gray-A700': '#616161',
    },
    extend: {},
    fontFamily: {
      'sans': ['Inter', ...defaultTheme.fontFamily.sans]
    }
  },
  variants: {
    extend: {
      transform: ['group-hover'],
      translate: ['group-hover'],
      textColor: ['group-hover']
    }
  },
  plugins: []
};
