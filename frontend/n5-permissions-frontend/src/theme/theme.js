import { createTheme } from '@mui/material/styles';

const palette = {
    primary: {
      main: '#556cd6',
    },
    secondary: {
      main: '#19857b', 
    },
    error: {
      main: '#ff1744', 
    },
    background: {
      default: '#f7f7f7', 
    },
  };
  
  
  const typography = {
    fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif',
    fontSize: 14,
    h1: {
      fontSize: '2rem',
    },
    h2: {
      fontSize: '1.75rem',
    },
  };
  
  
  const spacing = 8; 
  
  const theme = createTheme({
    palette,
    typography,
    spacing,
    components: {
        MuiButton: {
        styleOverrides: {
          root: {
            fontSize: '1rem',
          },
        },
      },
    },
  });

export default theme;
