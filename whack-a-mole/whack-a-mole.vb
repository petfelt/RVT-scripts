
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority local
declare global.number[4] with network priority local
declare global.number[5] with network priority low
declare global.number[6] with network priority low = 0
declare global.number[7] with network priority low
declare global.number[8] with network priority low
declare global.number[9] with network priority low
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority low
declare global.object[1] with network priority low
declare global.object[2] with network priority low
declare global.object[3] with network priority low
declare global.object[4] with network priority low
declare global.object[5] with network priority low
declare global.object[6] with network priority low
declare global.object[7] with network priority low
declare global.object[8] with network priority low
declare global.object[9] with network priority low
declare global.object[10] with network priority low
declare global.object[11] with network priority low
declare global.object[12] with network priority local
declare global.object[13] with network priority low
declare global.object[14] with network priority local
declare global.object[15] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority low
declare global.player[2] with network priority low
declare global.player[3] with network priority low
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare global.team[2] with network priority low
declare global.team[3] with network priority low
declare global.team[4] with network priority low
declare global.team[5] with network priority low
declare global.team[6] with network priority low
declare global.team[7] with network priority low
declare global.timer[0] = 15
declare global.timer[1] = 30
declare global.timer[2] = 3
declare player.number[0] with network priority local
declare player.number[1] with network priority low
declare player.number[2] with network priority low
declare player.number[3] with network priority local
declare player.number[4] with network priority local
declare player.number[5] with network priority low
declare player.object[0] with network priority low
declare player.timer[0] = 5
declare player.timer[1] = 1
declare player.timer[2] = 30
declare object.number[0] with network priority local
declare object.number[1] with network priority local
declare object.number[2] with network priority low
declare object.number[3] with network priority low
declare object.number[4] with network priority low
declare object.number[5] with network priority local
declare object.number[6] with network priority low
declare object.number[7] with network priority low
declare object.object[0] with network priority low
declare object.object[1] with network priority low
declare object.object[2] with network priority low
declare object.object[3] with network priority local
declare object.player[0] with network priority local
declare object.timer[3] = 3

function trigger_0()
   current_object.detach()
   if current_object.number[5] == 0 then 
      current_object.number[5] = current_object.spawn_sequence
      if current_object.spawn_sequence < -10 then 
         current_object.number[5] += 101
         current_object.number[5] *= 2
         if current_object.spawn_sequence > -71 then 
            current_object.number[5] *= 2
            if current_object.spawn_sequence > -41 then 
               current_object.number[5] *= 3
               current_object.number[5] /= 2
            end
         end
      end
      current_object.number[5] *= 10
      current_object.number[5] += 100
      if current_object.spawn_sequence < -10 then 
         current_object.number[5] += 1000
         if current_object.spawn_sequence > -71 then 
            current_object.number[5] += -600
            if current_object.spawn_sequence > -41 then 
               current_object.number[5] += -1200
            end
         end
      end
      if current_object.spawn_sequence == -10 then 
         current_object.number[5] = 1
      end
      current_object.set_scale(current_object.number[5])
      current_object.copy_rotation_from(current_object, false)
      if current_object.object[2] != no_object then 
         current_object.copy_rotation_from(current_object, true)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      current_object.number[0] = 1
   end
end

function checkDetachedWeapons()
end

function setWeapon()
   global.number[2] = script_option[8]
   for each player do
      if global.number[2] != 0 and current_player.number[2] == 0 then
         global.number[2] = script_option[9]
         current_player.biped.remove_weapon(secondary, true)
         global.object[6] = current_player.get_weapon(primary)
         if global.number[2] == 0 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(assault_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(assault_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(needler) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needler, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(plasma_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(plasma_repeater) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(spiker) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spiker, force)
               end
            end
            if global.number[6] == 5 then
               if not global.object[6].is_of_type(detached_machine_gun_turret) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
            end
            if global.number[6] == 6 then
               if not global.object[6].is_of_type(detached_plasma_cannon) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
            end
            if global.number[6] == 7 then
               if not global.object[6].is_of_type(sniper_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
            end
            if global.number[6] == 8 then
               if not global.object[6].is_of_type(focus_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
            if global.number[6] == 9 then
               if not global.object[6].is_of_type(needle_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needle_rifle, force)
               end
            end
            if global.number[6] == 10 then
               if not global.object[6].is_of_type(dmr) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(dmr, force)
               end
            end
            if global.number[6] == 11 then
               if not global.object[6].is_of_type(magnum) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(magnum, force)
               end
            end
            if global.number[6] == 12 then
               if not global.object[6].is_of_type(plasma_pistol) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
            end
            if global.number[6] == 13 then
               if not global.object[6].is_of_type(concussion_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
            end
            if global.number[6] == 14 then
               if not global.object[6].is_of_type(fuel_rod_gun) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
            end
            if global.number[6] == 15 then
               if not global.object[6].is_of_type(spartan_laser) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spartan_laser, force)
               end
            end
            if global.number[6] == 16 then
               if not global.object[6].is_of_type(grenade_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
            end
            if global.number[6] == 17 then
               if not global.object[6].is_of_type(rocket_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
         if global.number[2] == 1 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(assault_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(assault_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(needler) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needler, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(plasma_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(plasma_repeater) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(spiker) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spiker, force)
               end
            end
            if global.number[6] == 5 then
               if not global.object[6].is_of_type(detached_machine_gun_turret) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
            end
            if global.number[6] == 6 then
               if not global.object[6].is_of_type(detached_plasma_cannon) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
            end
         end
         if global.number[2] == 2 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(concussion_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(fuel_rod_gun) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(spartan_laser) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spartan_laser, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(grenade_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(rocket_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
         if global.number[2] == 3 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(sniper_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(focus_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
         end
         if global.number[2] == 4 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(sniper_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(focus_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(needle_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needle_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(dmr) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(dmr, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(magnum) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(magnum, force)
               end
            end
         end
         if global.number[2] == 5 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(sniper_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(focus_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(needle_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needle_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(dmr) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(dmr, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(magnum) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(magnum, force)
               end
            end
            if global.number[6] == 5 then
               if not global.object[6].is_of_type(plasma_pistol) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
            end
            if global.number[6] == 6 then
               if not global.object[6].is_of_type(concussion_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
            end
            if global.number[6] == 7 then
               if not global.object[6].is_of_type(fuel_rod_gun) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
            end
            if global.number[6] == 8 then
               if not global.object[6].is_of_type(spartan_laser) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spartan_laser, force)
               end
            end
            if global.number[6] == 9 then
               if not global.object[6].is_of_type(grenade_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
            end
            if global.number[6] == 10 then
               if not global.object[6].is_of_type(rocket_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
         if global.number[2] == 6 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(assault_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(assault_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(needler) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needler, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(plasma_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(plasma_repeater) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(spiker) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spiker, force)
               end
            end
            if global.number[6] == 5 then
               if not global.object[6].is_of_type(detached_machine_gun_turret) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
            end
            if global.number[6] == 6 then
               if not global.object[6].is_of_type(detached_plasma_cannon) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
            end
            if global.number[6] == 7 then
               if not global.object[6].is_of_type(sniper_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
            end
            if global.number[6] == 8 then
               if not global.object[6].is_of_type(focus_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
            if global.number[6] == 9 then
               if not global.object[6].is_of_type(needle_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needle_rifle, force)
               end
            end
            if global.number[6] == 10 then
               if not global.object[6].is_of_type(dmr) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(dmr, force)
               end
            end
            if global.number[6] == 11 then
               if not global.object[6].is_of_type(magnum) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(magnum, force)
               end
            end
            if global.number[6] == 12 then
               if not global.object[6].is_of_type(plasma_pistol) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
            end
         end
         if global.number[2] == 0 then
            if global.number[6] == 0 then
               if not global.object[6].is_of_type(assault_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(assault_rifle, force)
               end
            end
            if global.number[6] == 1 then
               if not global.object[6].is_of_type(needler) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needler, force)
               end
            end
            if global.number[6] == 2 then
               if not global.object[6].is_of_type(plasma_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
            end
            if global.number[6] == 3 then
               if not global.object[6].is_of_type(plasma_repeater) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
            end
            if global.number[6] == 4 then
               if not global.object[6].is_of_type(spiker) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spiker, force)
               end
            end
            if global.number[6] == 5 then
               if not global.object[6].is_of_type(detached_machine_gun_turret) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
            end
            if global.number[6] == 6 then
               if not global.object[6].is_of_type(detached_plasma_cannon) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
            end
            if global.number[6] == 7 then
               if not global.object[6].is_of_type(needle_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(needle_rifle, force)
               end
            end
            if global.number[6] == 8 then
               if not global.object[6].is_of_type(dmr) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(dmr, force)
               end
            end
            if global.number[6] == 9 then
               if not global.object[6].is_of_type(magnum) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(magnum, force)
               end
            end
            if global.number[6] == 10 then
               if not global.object[6].is_of_type(plasma_pistol) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
            end
            if global.number[6] == 11 then
               if not global.object[6].is_of_type(concussion_rifle) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
            end
            if global.number[6] == 12 then
               if not global.object[6].is_of_type(fuel_rod_gun) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
            end
            if global.number[6] == 13 then
               if not global.object[6].is_of_type(spartan_laser) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(spartan_laser, force)
               end
            end
            if global.number[6] == 14 then
               if not global.object[6].is_of_type(grenade_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
            end
            if global.number[6] == 15 then
               if not global.object[6].is_of_type(rocket_launcher) then
                  current_player.biped.remove_weapon(primary, true)
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
      end
   end
end

function newWeapon()
   global.number[2] = script_option[8]
   if global.number[2] != 0 then
      global.number[2] = script_option[9]
      if global.number[2] == 0 then
         global.number[10] = rand(18)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(assault_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(needler, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(spiker, force)
               end
               if global.number[10] == 5 then
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
               if global.number[10] == 6 then
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
               if global.number[10] == 7 then
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
               if global.number[10] == 8 then
                  current_player.biped.add_weapon(focus_rifle, force)
               end
               if global.number[10] == 9 then
                  current_player.biped.add_weapon(needle_rifle, force)
               end
               if global.number[10] == 10 then
                  current_player.biped.add_weapon(dmr, force)
               end
               if global.number[10] == 11 then
                  current_player.biped.add_weapon(magnum, force)
               end
               if global.number[10] == 12 then
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
               if global.number[10] == 13 then
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
               if global.number[10] == 14 then
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
               if global.number[10] == 15 then
                  current_player.biped.add_weapon(spartan_laser, force)
               end
               if global.number[10] == 16 then
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
               if global.number[10] == 17 then
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
      end
      if global.number[2] == 1 then
         global.number[10] = rand(7)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(assault_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(needler, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(spiker, force)
               end
               if global.number[10] == 5 then
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
               if global.number[10] == 6 then
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
            end
         end
      end
      if global.number[2] == 2 then
         global.number[10] = rand(5)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(spartan_laser, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
      end
      if global.number[2] == 3 then
         global.number[10] = rand(2)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(focus_rifle, force)
               end
            end
         end
      end
      if global.number[2] == 4 then
         global.number[10] = rand(5)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(focus_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(needle_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(dmr, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(magnum, force)
               end
            end
         end
      end
      if global.number[2] == 5 then
         global.number[10] = rand(11)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] == 0 then
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(focus_rifle, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(needle_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(dmr, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(magnum, force)
               end
               if global.number[10] == 5 then
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
               if global.number[10] == 6 then
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
               if global.number[10] == 7 then
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
               if global.number[10] == 8 then
                  current_player.biped.add_weapon(spartan_laser, force)
               end
               if global.number[10] == 9 then
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
               if global.number[10] == 10 then
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
      end
      if global.number[2] == 6 then
         global.number[10] = rand(13)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(assault_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(needler, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(spiker, force)
               end
               if global.number[10] == 5 then
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
               if global.number[10] == 6 then
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
               if global.number[10] == 7 then
                  current_player.biped.add_weapon(sniper_rifle, force)
               end
               if global.number[10] == 8 then
                  current_player.biped.add_weapon(focus_rifle, force)
               end
               if global.number[10] == 9 then
                  current_player.biped.add_weapon(needle_rifle, force)
               end
               if global.number[10] == 10 then
                  current_player.biped.add_weapon(dmr, force)
               end
               if global.number[10] == 11 then
                  current_player.biped.add_weapon(magnum, force)
               end
               if global.number[10] == 12 then
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
            end
         end
      end
      if global.number[2] == 7 then
         global.number[10] = rand(16)
         if global.number[10] == global.number[6] then
            newWeapon()
         end
         if global.number[10] != global.number[6] then
            global.number[6] = global.number[10]
            for each player do
               current_player.biped.remove_weapon(primary, true)
               game.show_message_to(current_player, timer_beep, ">>NEW WEAPON<<")
               if global.number[10] <= 0 then
                  current_player.biped.add_weapon(assault_rifle, force)
               end
               if global.number[10] == 1 then
                  current_player.biped.add_weapon(needler, force)
               end
               if global.number[10] == 2 then
                  current_player.biped.add_weapon(plasma_rifle, force)
               end
               if global.number[10] == 3 then
                  current_player.biped.add_weapon(plasma_repeater, force)
               end
               if global.number[10] == 4 then
                  current_player.biped.add_weapon(spiker, force)
               end
               if global.number[10] == 5 then
                  current_player.biped.add_weapon(detached_machine_gun_turret, force)
               end
               if global.number[10] == 6 then
                  current_player.biped.add_weapon(detached_plasma_cannon, force)
               end
               if global.number[10] == 7 then
                  current_player.biped.add_weapon(needle_rifle, force)
               end
               if global.number[10] == 8 then
                  current_player.biped.add_weapon(dmr, force)
               end
               if global.number[10] == 9 then
                  current_player.biped.add_weapon(magnum, force)
               end
               if global.number[10] == 10 then
                  current_player.biped.add_weapon(plasma_pistol, force)
               end
               if global.number[10] == 11 then
                  current_player.biped.add_weapon(concussion_rifle, force)
               end
               if global.number[10] == 12 then
                  current_player.biped.add_weapon(fuel_rod_gun, force)
               end
               if global.number[10] == 13 then
                  current_player.biped.add_weapon(spartan_laser, force)
               end
               if global.number[10] == 14 then
                  current_player.biped.add_weapon(grenade_launcher, force)
               end
               if global.number[10] == 15 then
                  current_player.biped.add_weapon(rocket_launcher, force)
               end
            end
         end
      end
   end
end

function trigger_3()
   if global.number[3] > 0 then
      global.object[3].push_upward()
      global.number[3] -= 1
      trigger_3()
   end
end

for each player do
   if current_player.number[2] == 1 then
      current_player.apply_traits(script_traits[1])
      global.object[3] = current_player.biped
      global.object[3].player[0] = current_player
      global.object[3].number[0] = script_option[10]
      if current_player.number[0] == 1 then
         global.object[3].number[0] += script_option[3]
      end
      global.object[3].set_waypoint_icon(territory_a, global.object[3].number[0])
   end
   if current_player.number[2] == 0 then
      current_player.apply_traits(script_traits[3])
   end
end

for each object with label "WAM_Molehill" do
   global.number[2] = script_option[7]
   if current_object.spawn_sequence > global.number[2] then
      current_object.delete()
   end
   global.timer[0].set_rate(-300%)
   if current_object.object[0] == no_object then
      global.number[5] = rand(15)
      if global.number[5] <= 0 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, carter)
      end
      if global.number[5] == 1 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, jun)
      end
      if global.number[5] == 2 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, female)
      end
      if global.number[5] == 3 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, male)
      end
      if global.number[5] == 4 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, emile)
      end
      if global.number[5] == 5 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, player_skull)
      end
      if global.number[5] == 6 then
         current_object.object[0] = current_object.place_at_me(spartan, "WAM_Mole", never_garbage_collect, 0, 0, -10, kat)
      end
      if global.number[5] > 6 then
         current_object.object[0] = current_object.place_at_me(elite, "WAM_Mole", never_garbage_collect, 0, 0, -10, mp)
      end
      global.object[4] = current_object.object[0]
      global.object[4].number[0] = 0
      current_object.object[0].attach_to(current_object, 0, 0, -10, relative)
      current_object.object[0].detach()
      global.object[4].object[0] = current_object
   end
end

if global.timer[0].is_zero() then
   global.number[3] = rand(8)
   global.object[3] = get_random_object("WAM_Mole", global.object[3])
   if global.number[3] < 3 then
      global.number[3] = 3
   end
   if global.number[3] >= 6 then
      global.object[3].number[0] = script_option[13]
   end
   if global.number[3] <= 5 then
      global.object[3].number[0] = script_option[12]
   end
   if global.number[3] <= 3 then
      global.object[3].number[0] = script_option[11]
   end
   global.object[3].set_waypoint_icon(territory_a, global.object[3].number[0])
   trigger_3()
   global.number[2] = rand(7)
   if global.number[2] == 0 then
      global.number[2] = 1
   end
   global.timer[0].reset()
   global.timer[0] = global.number[2]
end

for each object with label "WAM_AboveGround" do
   global.object[5] = current_object
   for each object with label "WAM_Mole" do
      if global.object[5].shape_contains(current_object) then
         current_object.number[1] = 1
         current_object.set_waypoint_visibility(everyone)
      alt
         current_object.set_waypoint_visibility(no_one)
         if current_object.number[1] == 1 then
            current_object.number[1] = 2
         end
      end
   end
   for each player do
      if current_player.number[2] == 1 then
         current_player.timer[1].set_rate(200%)
         if global.object[5].shape_contains(current_object) then
            current_object.set_waypoint_visibility(everyone)
            if current_player.timer[1].is_zero() then
               global.number[2] = script_option[11]
               current_player.score += global.number[2]
               current_player.timer[1].reset()
            end
         alt
            current_object.set_waypoint_visibility(no_one)
            current_player.apply_traits(script_traits[2])
         end
      end
   end
end

for each object with label "WAM_Mole" do
   if current_object.number[1] == 2 then
      current_object.delete()
   end
end

if game.teams_enabled == 1 then 
   for each object with label "WAM_SwapTeams" do
      current_object.delete()
   end
end

if game.teams_enabled == 0 then 
   for each object with label "WAM_SwapTeams" do
      current_object.set_waypoint_range(0, 15)
      current_object.set_waypoint_visibility(everyone)
      if current_object.spawn_sequence == 0 then
         current_object.set_waypoint_text("GO HUNTING")
      end
      if current_object.spawn_sequence != 0 then
         current_object.set_waypoint_text("BECOME A MOLE")
      end
      for each player do
         global.number[5] = current_object.get_distance_to(current_player.biped)
         if global.number[5] <= 120 then
            current_object.set_shape_visibility(mod_player, current_player, 1)

         end
         if global.number[5] > 120 then
            current_object.set_shape_visibility(mod_player, current_player, 0)
         end
         if current_object.shape_contains(current_player.biped) then
            current_player.timer[0].reset()
            if current_object.spawn_sequence != 0 then
               current_player.team = team[1]
               current_player.number[2] = 1
               script_widget[1].set_visibility(current_player, true)
            end
            if current_object.spawn_sequence == 0 then
               current_player.team = team[0]
               current_player.number[2] = 0
               script_widget[0].set_visibility(current_player, true)
            end
            send_incident(suicide, current_player, no_player)
            current_player.biped.kill(false)
         end
      end
   end
end

for each player do
   if current_player.number[2] == 1 then 
      current_player.set_loadout_palette(elite_tier_1)
   end
   if current_player.number[2] == 0 then
      current_player.set_loadout_palette(spartan_tier_1)
   end
   for each object with label "WAM_ClubOnMap" do
      current_player.number[5] = 1
   end
   if current_player.number[5] > 0 then
      global.object[6] = current_player.get_weapon(primary)
      if global.object[6].is_of_type(gravity_hammer) then
         current_player.biped.remove_weapon(primary, true)
         current_player.biped.add_weapon(golf_club, force)
      end
   end
end

for each player do
   if game.score_to_win != 0 then 
      current_player.set_round_card_title("Hunters score points by killing moles.\nMoles score points by jumping.\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win == 0 then 
      current_player.set_round_card_title("Hunters score points by killing moles.\nMoles score points by jumping.")
   end
end

for each player do
   current_player.timer[0].set_rate(-100%)
   if current_player.timer[0].is_zero() then
      script_widget[0].set_visibility(current_player, false)
      script_widget[1].set_visibility(current_player, false)
      script_widget[2].set_visibility(current_player, false)
      global.number[2] = script_option[8]
      if global.number[2] > 0 then
         script_widget[2].set_visibility(current_player, true)
      end
   end
   if current_player.number[1] == 0 and current_player.timer[0].is_zero() then 
      script_widget[0].set_text("You are a HUNTER: Shoot the moles!")
      script_widget[1].set_text("You are a pesky MOLE: Jump and avoid gunfire!")
      if game.teams_enabled == 0 then
         current_player.team = team[0]
         current_player.number[2] = 0
         for each object with label "WAM_SwapTeams" do
            current_object.set_shape_visibility(no_one)
         end
      end
      game.show_message_to(current_player, none, "Idea - Sofasleeper5 ||| AnvilEditor - Weesee! Release V1.05a")
      game.show_message_to(current_player, announce_slayer, "Whack-A-Mole - v0.97 - Created by mini nt")
      current_player.number[1] = 1
      current_player.timer[0].reset()
   end
   if current_player.number[1] == 1 and current_player.timer[0].is_zero() then
      if current_player.number[2] == 0 then
         script_widget[0].set_visibility(current_player, true)
      end
      if current_player.number[2] != 0 then
         script_widget[1].set_visibility(current_player, true)
      end
      current_player.number[1] = 2
      current_player.timer[0].reset()
   end
end

if not global.timer[1].is_zero() then
   global.timer[2].set_rate(-100%)
   global.timer[1].set_rate(-100%)
   script_widget[2].set_text("WEAPON SWAP: %n", global.timer[1])
end

if global.timer[1].is_zero() then
   newWeapon()
   for each player do
      current_player.number[4] = global.number[6]
      current_player.number[5] = 1
   end
   global.timer[1].reset()
end

if global.timer[2].is_zero() then
   setWeapon()
   global.timer[2].reset()
end

for each player do
   global.number[1] = 0
   current_player.script_stat[0] = current_player.rating
   current_player.number[0] = 0
   if game.teams_enabled == 1 then 
      global.number[1] = current_player.team.get_scoreboard_pos()
   end
   if game.teams_enabled == 0 then 
      global.number[1] = current_player.get_scoreboard_pos()
   end
   if global.number[1] == 1 and not current_player.score == 0 then 
      current_player.number[0] = 1
   end
end

for each player do
   global.number[1] = 0
   global.object[8] = current_player.biped
   if global.object[8] != no_object then
      global.object[8].player[0] = current_player
   end
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      if current_player.killer_type_is(kill) then 
         global.player[0] = current_player.try_get_killer()
         global.player[0].score += script_option[0]
         global.number[2] = script_option[0]
         if global.number[2] != 0 then
            game.show_message_to(current_player, none, "+%n", global.number[2])
         end
         global.number[4] = current_player.try_get_death_damage_mod()
         global.number[1] = global.player[0].get_spree_count()
         do
            global.number[1] %= 5
            if global.number[1] == 0 then 
               global.player[0].score += script_option[2]
               global.number[2] = script_option[2]
               if global.number[2] != 0 then
                  game.show_message_to(current_player, none, "+%n", global.number[2])
               end
            end
         end
         if current_player.number[0] == 1 then 
            global.player[0].score += script_option[3]
            global.number[2] = script_option[3]
            if global.number[2] != 0 then
               game.show_message_to(current_player, none, "+%n", global.number[2])
            end
         end
         if global.number[4] == 3 then 
            global.player[0].score += script_option[5]
            global.number[2] = script_option[5]
            if global.number[2] != 0 then
               game.show_message_to(current_player, none, "+%n", global.number[2])
            end
         end
         if global.number[4] == 4 then 
            global.player[0].score += script_option[6]
            global.number[2] = script_option[6]
            if global.number[2] != 0 then
               game.show_message_to(current_player, none, "+%n", global.number[2])
            end
         end
         if global.number[4] == 5 then 
            global.player[0].score += script_option[4]
            global.number[2] = script_option[4]
            if global.number[2] != 0 then
               game.show_message_to(current_player, none, "+%n", global.number[2])
            end
         end
      end
   end
end

on object death: do
   if killed_object.has_forge_label("WAM_Mole") or killed_object.is_of_type(spartan) or killed_object.is_of_type(elite) then
      killer_player.score += killed_object.number[0]
      game.show_message_to(killer_player, none, "+%n", killed_object.number[0])
      killed_object.delete()
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) and not current_player.killer_type_is(kill) and not current_player.killer_type_is(betrayal) then 
      current_player.score += script_option[1]
   end
end

for each player do
   if current_player.number[0] == 1 then 
      current_player.apply_traits(script_traits[0])
   end
end

for each object do
   if not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) and current_object.team == team[7] then 
      current_object.set_invincibility(1)
   end
end

for each player do
   if script_option[14] == 1 then 
      current_player.set_co_op_spawning(true)
   end
   if script_option[15] == 1 then 
      current_player.biped.set_invincibility(1)
   end
end

for each object with label "attach_base" do
   if current_object.spawn_sequence != 0 then 
      global.object[0] = no_object
      global.object[0] = current_object
      global.number[8] = current_object.spawn_sequence
      global.number[8] *= -1
      for each object with label "attachment" do
         if current_object.spawn_sequence != 0 and global.object[0].spawn_sequence == current_object.spawn_sequence or global.number[8] == current_object.spawn_sequence and current_object.number[1] == 0 then 
            if current_object.spawn_sequence < 0 then 
               global.object[2] = current_object
               for each object do
                  global.number[7] = current_object.get_distance_to(global.object[2])
                  global.player[3] = current_object.try_get_carrier()
                  if global.number[7] == 0 and global.player[3] == no_player and global.object[2] != current_object and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
                     current_object.detach()
                     current_object.attach_to(global.object[0], 0, 0, 5, relative)
                     if current_object.is_of_type(warthog_turret_rocket) or current_object.is_of_type(warthog_turret_gauss) or current_object.is_of_type(warthog_turret) or current_object.is_of_type(shade_gun_plasma) then 
                        current_object.object[0] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, none)
                        current_object.object[0].set_scale(1)
                        current_object.detach()
                        current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
                        current_object.object[0].attach_to(global.object[0], 0, 0, 5, relative)
                        global.object[0].object[0] = current_object
                        current_object.object[0].set_shape(box, 5, 5, 10, 0)
                     end
                  end
               end
               current_object.attach_to(global.object[0], 0, 0, 0, relative)
               current_object.number[1] = 1
               if current_object.spawn_sequence < -50 then 
                  current_object.set_scale(1)
               end
            end
            if current_object.spawn_sequence > 74 then 
               global.object[2] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, troop)
               global.object[2].set_scale(1)
               global.object[2].attach_to(global.object[0], 0, 0, 0, relative)
               current_object.attach_to(global.object[2], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
            if current_object.spawn_sequence > 0 then 
               current_object.attach_to(global.object[0], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
         end
      end
      for each object do
         if global.object[0].spawn_sequence < 0 then 
            global.object[0].set_shape_visibility(everyone)
            if global.object[0].team == current_object.team or global.object[0].team == neutral_team and global.object[0].shape_contains(current_object) and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
               current_object.attach_to(global.object[0], 0, 0, 0, relative)
            end
         end
      end
   end
end

for each object with label "spawner" do
   if current_object.object[0] == no_object then 
      current_object.number[0] = current_object.spawn_sequence
      if current_object.spawn_sequence == 1 then 
         current_object.object[0] = current_object.place_at_me(bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 2 then 
         current_object.object[0] = current_object.place_at_me(covenant_bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 3 then 
         current_object.object[0] = current_object.place_at_me(flag, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 4 then 
         current_object.object[0] = current_object.place_at_me(skull, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 5 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 6 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 7 then 
         current_object.object[0] = current_object.place_at_me(spartan, none, never_garbage_collect, 0, 0, 0, player_skull)
      end
      if current_object.spawn_sequence == 8 then 
         current_object.object[0] = current_object.place_at_me(elite, none, never_garbage_collect, 0, 0, 0, jetpack)
      end
      if current_object.spawn_sequence == 9 then 
         current_object.object[0] = current_object.place_at_me(pelican_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 10 then 
         current_object.object[0] = current_object.place_at_me(phantom_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 11 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 12 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_gauss, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.team == team[1] and current_object.object[1] == no_object then 
            current_object.object[1] = current_object.place_at_me(flag_stand, none, never_garbage_collect, 0, 0, 0, none)
            current_object.object[2] = current_object.place_at_me(shade, none, never_garbage_collect, 0, 0, 0, none)
            current_object.object[2].set_shape(cylinder, 10, 10, 0)
            global.object[13] = current_object.object[2]
            for each object do
               if global.object[13].shape_contains(current_object) and current_object.is_of_type(shade_gun_plasma) then 
                  current_object.delete()
               end
            end
            current_object.object[2].set_scale(10)
            current_object.object[1].set_scale(1)
            current_object.object[2].attach_to(current_object.object[0], 0, 0, 0, relative)
            current_object.object[2].detach()
            current_object.object[1].attach_to(current_object.object[2], 0, 0, 0, relative)
            current_object.object[0].attach_to(current_object.object[1], 0, 0, 0, relative)
         end
      end
      if current_object.spawn_sequence == 13 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_rocket, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 14 then 
         current_object.object[0] = current_object.place_at_me(phantom, none, never_garbage_collect, 0, 0, 0, none)
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
      if current_object.spawn_sequence == 15 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 16 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_module_stand, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 17 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core_holder, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 18 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
      current_object.object[0].copy_rotation_from(current_object, true)
      if current_object.team == team[0] and current_object.spawn_sequence != -5 then 
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   if current_object.spawn_sequence == -5 and current_object.object[0] == no_object then 
      if current_object.team != team[3] then 
         current_object.object[0] = current_object.place_at_me(heavy_barrier, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.object[0] == no_object then 
            current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
         end
      end
      if current_object.team == team[3] then 
         current_object.object[0] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      current_object.object[0].set_invincibility(1)
      current_object.object[0].set_scale(50)
      current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      current_object.object[0].detach()
      current_object.object[0].copy_rotation_from(current_object, true)
      current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
      current_object.object[0].copy_rotation_from(current_object.object[0], false)
   end
   if current_object.spawn_sequence == -6 or current_object.spawn_sequence == -7 and current_object.number[2] == 0 then 
      global.object[7] = no_object
      global.object[7] = current_object
      for each object do
         global.number[7] = current_object.get_distance_to(global.object[7])
         if global.number[7] == 0 and global.object[7] != current_object then 
            if global.object[7].spawn_sequence == -7 then 
               current_object.delete()
            end
            if global.object[7].spawn_sequence == -6 then 
               current_object.attach_to(global.object[7], 0, 0, 0, relative)
            end
            global.object[7].number[2] = 1
         end
      end
   end
   if current_object.spawn_sequence == -8 or current_object.spawn_sequence == -9 then 
      global.object[12] = current_object
      for each object do
         if global.object[12].shape_contains(current_object) and global.object[12].team == current_object.team or global.object[12].team == neutral_team then 
            if global.object[12].spawn_sequence == -8 then 
               current_object.set_invincibility(1)
            end
            if global.object[12].spawn_sequence == -9 then 
               current_object.set_invincibility(0)
            end
         end
      end
   end
end

for each object with label "bro_spawn_loc" do
   current_object.set_invincibility(1)
   current_object.set_pickup_permissions(no_one)
   current_object.set_spawn_location_fireteams(all)
   current_object.set_spawn_location_permissions(allies)
   for each player do
      if current_object.team == current_player.team or current_object.team == neutral_team then 
         current_player.set_primary_respawn_object(current_object)
      end
   end
end

for each object with label "scale" do
   if current_object.number[0] == 0 then 
      if current_object.team == team[2] then 
         current_object.object[2] = current_object.place_at_me(heavy_barrier, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.object[2] == no_object then 
            current_object.object[2] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
         end
      end
      if current_object.team == team[3] then 
         current_object.object[2] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.object[2] != no_object then 
         current_object.object[2].set_invincibility(1)
         current_object.object[2].set_scale(50)
         current_object.object[2].attach_to(current_object, 0, 0, 0, relative)
         current_object.object[2].detach()
         current_object.object[2].copy_rotation_from(current_object, false)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      trigger_0()
   end
end

on local: do
   for each object with label "object_by_index" do
      if current_object.timer[3].is_zero() then 
         current_object.object[3].detach()
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.timer[3].reset()
      end
      if current_object.object[3] == no_object then 
         current_object.timer[3].set_rate(-100%)
         global.number[11] = current_object.spawn_sequence
         global.number[11] += 100
         global.object[14] = no_object
         global.number[9] = 0
         for each object do
            if not current_object.is_of_type(monitor) and not current_object.is_of_type(flag_stand) and not current_object.is_of_type(kill_ball) and not current_object.is_of_type(elite) and not current_object.is_of_type(spartan) and not current_object.is_of_type(landmine) and not current_object.is_of_type(hill_marker) and not current_object.is_of_type(capture_plate) then 
               if global.number[9] == global.number[11] then 
                  global.object[14] = current_object
               end
               global.number[9] += 1
            end
         end
         current_object.object[3] = global.object[14]
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.object[3].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   for each object with label "scale" do
      if current_object.number[0] == 0 then 
         if current_object.team == team[2] or current_object.team == team[3] and current_object.object[2] != no_object then 
            trigger_0()
            current_object.copy_rotation_from(current_object, true)
            current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
         end
         if current_object.team != team[2] and current_object.team != team[3] then 
            trigger_0()
         end
      end
      if current_object.is_of_type(hill_marker) then 
         current_object.set_shape_visibility(everyone)
         if current_object.team == team[7] or current_object.team == team[5] then 
            current_object.number[5] = current_object.spawn_sequence
            if current_object.spawn_sequence == 0 then 
               current_object.number[5] = 100
            end
            if current_object.spawn_sequence < 0 then 
               current_object.number[5] *= -1
               current_object.number[5] += 100
            end
         end
         global.object[15] = current_object
         for each object do
            if global.object[15].team == current_object.team or global.object[15].team == neutral_team or global.object[15].team == team[5] or global.object[15].team == team[6] or global.object[15].team == team[7] and global.object[15].shape_contains(current_object) and global.object[15] != current_object and current_object.number[7] != 9999 then 
               current_object.set_scale(global.object[15].number[1])
               current_object.copy_rotation_from(current_object, false)
               if global.object[15].team == team[6] or global.object[15].team == team[7] then 
                  current_object.number[7] = 9999
               end
            end
         end
      end
   end
   for each object with label "spawner" do
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
   end
end

if game.round_time_limit > 0 and game.round_timer.is_zero() then 
   game.end_round()
end
