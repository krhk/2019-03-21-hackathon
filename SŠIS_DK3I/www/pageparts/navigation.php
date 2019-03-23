
<nav id="mySidenav" class="sidenav">
    <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
    <a href="<?php echo (URL);?>"><i class="fas fa-home"></i>  |   Hlavní</a>
    <a href="<?php echo (URL . "/vyhledavani_zastavek");?>"><i class="fas fa-search"></i>  | Vyhledávání</a>
    <a href="<?php echo (URL . "/vypis_zastavek");?>"><i class="fas fa-clipboard-list"></i>  |  Seznam zastávek</a>
    <?php if (is_user_logged_in()) { ?>
          <hr class="menu_hr">
          <a href="<?php echo (ADMINURL);?>"><i class="fas fa-tools"></i>  |  Administrace</a>
          <a href="<?php echo (ADMINURL . "?p=upravit_zastavky");?>"><i class="far fa-edit"></i>  |  Upravit zastávky</a>
          <a href="<?php echo (ADMINURL . "?p=pridat_uzivatele");?>"><i class="fas fa-user-plus"></i>  |  Přidat uživatele</a>
          <a class="position-absolute fixed-bottom" style="right: 10px;" href="<?php echo (LOGOUTURL);?>"><i class="fas fa-sign-out-alt"></i>  |  Odhlásit se</a>
    <?php } else {?>
        <a class="position-absolute fixed-bottom" style="right: 10px;" href="<?php echo (LOGINURL);?>"><small style="font-size:130%;color:white;"><i class="fas fa-sign-in-alt">  |  </i>Přihlásit se</small></a>
    <?php } ?>
</nav>
