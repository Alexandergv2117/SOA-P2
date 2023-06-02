/* eslint-disable no-undef */
import styles from './Header.module.css'

const hostFront = import.meta.env.VITE_HOST_FRONT

export const Header = () => {

  const GoToEmployees = () => {
    window.location.href = `${hostFront}/employees`
  }
  const GoToAssets = () => {
    window.location.href = `${hostFront}/assets`
  }
  const GoToAssetsEmployees = () => {
    window.location.href = `${hostFront}/assetsEmployees`
  }

  return (
    <div className={styles.header}>
      <button className={styles.btn} onClick={GoToEmployees}>Employees</button>
      <button className={styles.btn} onClick={GoToAssets}>Assets</button>
      <button className={styles.btn} onClick={GoToAssetsEmployees}>Assets-Employees</button>
    </div>
  )
}
