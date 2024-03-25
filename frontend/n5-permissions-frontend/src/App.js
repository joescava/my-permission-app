import React from 'react';
import { ThemeProvider } from '@mui/material/styles';
import theme from './theme/theme';
import PermissionPage from './views/PermissionPage';

function App() {
  return (
    <ThemeProvider theme={theme}>
      <PermissionPage />
    </ThemeProvider>
  );
}

export default App;